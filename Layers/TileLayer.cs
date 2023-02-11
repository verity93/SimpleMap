using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Drawing;
using SimpleMap.Framework;
using SimpleMap.Framework.WorkerThread;
using SimpleMap.Framework.WorkerThread.Types;
using SimpleMap.Map;
using SimpleMap.Map.Tile;

namespace SimpleMap.Layers
{
    //Source Tiles from 
    //https://github.com/jaypwagner/SharpMappingWinform/blob/master/Form1.cs
    //https://github.com/mapserver/mapserver
    public class TileLayer : GraphicLayer
    {
        private const int MaxCacheSize = 512; //240

        private Rectangle _blockView;
        private readonly Bitmap _emptyBlock;       

        protected class MapWorkerEvent : WorkerEvent
        {
            public TileBlock Block;

            public MapWorkerEvent(WorkerEventType eventType, TileBlock block, EventPriorityType priorityType)
                : base(eventType, true, priorityType)
            {
                Block = block;
            }
            
            override public int CompareTo(object obj)
            {
                var res = base.CompareTo(obj);
                if (res == 0)
                {
                    if (obj != null)
                    {
                        res = ((MapWorkerEvent) obj).Block.CompareTo(Block);
                    }
                    else
                    {
                        res = -1;
                    }
                }
                return res;
            }
        }

        private struct MapCacheItem
        {
            public long Timestamp;
            public Bitmap Bmp;
        };

        private static readonly SortedDictionary<TileBlock, MapCacheItem> MapCache = new SortedDictionary<TileBlock, MapCacheItem>();

        public TileLayer(int width, int height, GeomCoordinate centerCoordinate, int level)
            : base(width, height, centerCoordinate, level)
        {
            _emptyBlock = CreateCompatibleBitmap(null, TileBlock.BlockSize, TileBlock.BlockSize, PiFormat);
        }

        override protected void TranslateCoords()
        {
            base.TranslateCoords();

            _blockView = ScreenView.BlockView;
        }
        
        private void PutMapThreadEvent(WorkerEventType eventType, TileBlock block, EventPriorityType priorityType)
        {
            PutWorkerThreadEvent(new MapWorkerEvent(eventType, block, priorityType));
        }

        override protected void DrawLayer(Rectangle clipRectangle)
        {
            try
            {
                SwapDrawBuffer();

                Rectangle localBlockView;
                ScreenRectangle localScreenView;
                do
                {
                    DropWorkerThreadEvents(WorkerEventType.RedrawLayer);

                    localBlockView = (Rectangle) _blockView.Clone();
                    localScreenView = (ScreenRectangle) ScreenView.Clone();
                } 
                while (DrawImages(localBlockView, localScreenView) == false);
            }
            finally
            {
                SwapDrawBuffer();
            }
            FireInvalidateLayer(clipRectangle);
        }

        private bool DrawImages(Rectangle localBlockView, ScreenRectangle localScreenView)
        {
            for (var x = localBlockView.Left; x <= localBlockView.Right; x++)
            {
                for (var y = localBlockView.Top; y <= localBlockView.Bottom; y++)
                {
                    var block = new TileBlock(x, y, Level);
                    var pt = ((ScreenCoordinate)block).GetScreenPoint(localScreenView);

                    var bmp = FindImage(block);
                    if (bmp != null)
                    {
                        DrawBitmap(bmp, pt);
                    }
                    else
                    {
                        DrawBitmap(_emptyBlock, pt);
                        PutMapThreadEvent(WorkerEventType.DownloadImage, block, EventPriorityType.Idle);
                    }

                    if (Terminating) return true;

                    if (localScreenView.CompareTo(ScreenView) != 0) return false;
                }
            }
            return true;
        }

        private void DrawImage(TileBlock block)
        {
            if (Terminating) return;

            if (block.Level == Level && block.Pt.Contains(_blockView))
            {
                var bmp = FindImage(block);
                if (bmp != null)
                {
                    var rect = ((ScreenRectangle)block).GetScreenRect(ScreenView);
                    DrawBitmap(bmp, rect.Location);

                    FireInvalidateLayer(rect);
                }
            }
        }

        private static Bitmap FindImage(TileBlock block)
        {
            if (MapCache.ContainsKey(block))
            {
                var dimg = MapCache[block];
                dimg.Timestamp = DateTime.Now.Ticks;
                return dimg.Bmp;
            }
            return null;
        }

        protected override bool SetCenterCoordinate(GeomCoordinate center, int level)
        {
            var res = base.SetCenterCoordinate(center, level);
            
            if (res)
                DropWorkerThreadEvents(WorkerEventType.DownloadImage);

            return res;
        }

        protected override bool DispatchThreadEvents(WorkerEvent workerEvent)
        {
            var res = base.DispatchThreadEvents(workerEvent);

            if (!res && workerEvent is MapWorkerEvent)
            {
                switch (workerEvent.EventType)
                {
                    case WorkerEventType.DownloadImage:
                        {
                            DownloadImage(((MapWorkerEvent)workerEvent).Block);
                            return true;
                        }
                    case WorkerEventType.DrawImage:
                        {
                            DrawImage(((MapWorkerEvent)workerEvent).Block);
                            return true;
                        }
                }
            }

            return res;
        }

        private void DownloadImage(TileBlock block)
        {
            if (MapCache.ContainsKey(block))
            {
                var dimg = MapCache[block];
                if (dimg.Bmp != null) //to turn off compile warning
                {
                    dimg.Timestamp = DateTime.Now.Ticks;
                }
            }
            else
            {
                var bmp = DownloadImageFromFile(block) ?? DownloadImageFromTile(block, true);

                if (bmp != null)
                {
                    bmp = CreateCompatibleBitmap(bmp, TileBlock.BlockSize, TileBlock.BlockSize, PiFormat);

                    var dimg = new MapCacheItem { Timestamp = DateTime.Now.Ticks, Bmp = bmp };
                    try
                    {
                        MapCache[block] = dimg;

                        TruncateImageCache(block);

                        PutMapThreadEvent(WorkerEventType.DrawImage, block, EventPriorityType.Low);
                    }
                    catch
                    {
                        //System.NullReferenceException
                    }
                }
            }
        }

        private void TruncateImageCache(TileBlock newCacheItem)
        {
            while (MapCache.Count > MaxCacheSize)
            {
                var mt = TileBlock.Empty;
                var lTicks = DateTime.Now.Ticks;

                foreach (var lt in MapCache)
                {
                    if (lt.Value.Timestamp < lTicks && lt.Key.CompareTo(newCacheItem) != 0)
                    {
                        mt = lt.Key;
                        lTicks = lt.Value.Timestamp;
                    }
                }

                if (mt != TileBlock.Empty)
                    MapCache.Remove(mt);
            }
        }

        public static Bitmap DownloadImageFromTile(TileBlock block, bool getBitmap)
        {
            try
            {
                var oRequest = MapUtilities.CreateTileWebRequest(block);
                var oResponse = (HttpWebResponse) oRequest.GetResponse();

                var bmpStream = new MemoryStream();
                var oStream = oResponse.GetResponseStream();
                if (oStream != null) oStream.CopyTo(bmpStream);
                oResponse.Close();
                if (bmpStream.Length > 0)
                {
                    WriteImageToFile(block, bmpStream);
                    return getBitmap ? (Bitmap) Image.FromStream(bmpStream) : null;
                }
            }
            catch (Exception ex)
            {
                //do nothing
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
            return null;
        }

        public static Bitmap DownloadImageFromFile(TileBlock block)
        {
            try
            {
                var fileName = Properties.Settings.GetMapFileName(block);
                if (File.Exists(fileName))
                {
                    var bmp = (Bitmap)Image.FromFile(fileName);
                    return bmp;
                }
            }
            catch (Exception ex)
            {
                //do nothing
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
            return null;
        }

        private static void WriteImageToFile(TileBlock block, Stream bmpStream)
        {
            var fileName = Properties.Settings.GetMapFileName(block);
            try
            {
                if (!File.Exists(fileName))
                {
                    var path = Path.GetDirectoryName(fileName) ?? "";
                    var destdir = new DirectoryInfo(path);
                    if (!destdir.Exists)
                    {
                        destdir.Create();
                    }
                    var fileStream = File.Create(fileName);
                    try
                    {
                        bmpStream.Seek(0, SeekOrigin.Begin);
                        bmpStream.CopyTo(fileStream);
                    }
                    finally
                    {
                        fileStream.Flush();
                        fileStream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //do nothing
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }
    }
}
