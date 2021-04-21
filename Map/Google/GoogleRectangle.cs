using System;
using System.Drawing;
using ProgramMain.Map.Types;

namespace ProgramMain.Map.Tile
{
    public class ScreenRectangle : ICloneable, IComparable
    {
        public static readonly ScreenRectangle Empty = new ScreenRectangle();

        public ScreenCoordinate LeftTop
        {
            get
            {
                return new ScreenCoordinate(Left, Top, Level);
            }
        }

        public ScreenCoordinate RightBottom
        {
            get
            {
                return new ScreenCoordinate(Right, Bottom, Level);
            }
        }

        public long Left { get; private set; }

        public long Right { get; private set; }

        public long Top { get; private set; }

        public long Bottom { get; private set; }

        public int Level { get; private set; }

        private ScreenRectangle()
        {
            Left = 0;
            Right = 0;
            Top = 0;
            Bottom = 0;
            Level = 0;
        }

        public ScreenRectangle(long left, long top, long right, long bottom, int level)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
            Level = level;
        }

        public ScreenRectangle(ScreenCoordinate pLeftTop, ScreenCoordinate pRightBottom)
        {
            if (pRightBottom.Level != pLeftTop.Level)
            {
                pRightBottom = new ScreenCoordinate(pRightBottom, pLeftTop.Level);
            }
            Left = pLeftTop.X;
            Top = pLeftTop.Y;
            Right = pRightBottom.X;
            Bottom = pRightBottom.Y;
            Level = pLeftTop.Level;
        }

        public ScreenRectangle(CoordinateRectangle coordinateRect, int level)
        {
            var pLeftTop = new ScreenCoordinate(coordinateRect.LeftTop, level);
            var pRightBottom = new ScreenCoordinate(coordinateRect.RightBottom, level);
            Left = pLeftTop.X;
            Top = pLeftTop.Y;
            Right = pRightBottom.X;
            Bottom = pRightBottom.Y;
            Level = level;
        }

        public ScreenRectangle(CoordinatePoligon coordinatePoligon, int level)
        {
            for (var i = 0; i < coordinatePoligon.Count; i++)
            {
                var pt = new ScreenCoordinate(coordinatePoligon.Coordinates[i], level);
                if (i == 0)
                {
                    Left = pt.X;
                    Right = pt.X;
                    Top = pt.Y;
                    Bottom = pt.Y;
                }
                else
                {
                    if (pt.X < Left) Left = pt.X;
                    if (pt.X > Right) Right = pt.X;
                    if (pt.Y < Top) Top = pt.Y;
                    if (pt.Y > Bottom) Bottom = pt.Y;
                }
            }
                
            Level = level;
        }

        #region ICloneable Members
        public object Clone()
        {
            return new ScreenRectangle(Left, Top, Right, Bottom, Level);
        }
        #endregion

        #region IComparable Members
        public int CompareTo(Object obj)
        {
            var rectangle = (ScreenRectangle)obj;
            var res = LeftTop.CompareTo(rectangle.LeftTop);
            if (res != 0) return res;
            return RightBottom.CompareTo(rectangle.RightBottom);
        }
        #endregion

        public static implicit operator CoordinateRectangle(ScreenRectangle Tile)
        {
            return new CoordinateRectangle(Tile.LeftTop, Tile.RightBottom);
        }

        /// <summary>
        /// Tile bitmap block count for (X, Y)
        /// </summary>
        public Rectangle BlockView
        {
            get
            {
                return Rectangle.FromLTRB(
                    (int) (Left / TileBlock.BlockSize),
                    (int) (Top / TileBlock.BlockSize),
                    (int) ((Right - TileBlock.BlockSize) / TileBlock.BlockSize) + 1,
                    (int) ((Bottom - TileBlock.BlockSize) / TileBlock.BlockSize) + 1);
            }
        }

        public Rectangle GetScreenRect(ScreenRectangle screenView)
        {
            if (Level != screenView.Level)
            {
                screenView = new ScreenRectangle(
                    new CoordinateRectangle(screenView.LeftTop, screenView.RightBottom), Level);
            }

            var pt1 = LeftTop.GetScreenPoint(screenView);
            var pt2 = RightBottom.GetScreenPoint(screenView);

            return Rectangle.FromLTRB(pt1.X, pt1.Y, pt2.X, pt2.Y);
        }

        public IntersectResult PointContains(GeomCoordinate point)
        {
            return ((CoordinateRectangle)this).PointContains(point);
        }

        public IntersectResult RectangleContains(CoordinateRectangle rectangle)
        {
            return ((CoordinateRectangle)this).RectangleContains(rectangle);
        }

        public IntersectResult LineContains(CoordinateRectangle line)
        {
            return ((CoordinateRectangle)this).LineContains(line);
        }

        public IntersectResult PoligonContains(CoordinatePoligon poligon)
        {
            return ((CoordinateRectangle)this).PoligonContains(poligon);
        }
    }
}
