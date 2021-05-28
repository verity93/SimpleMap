using System;
using System.Drawing;

namespace SimpleMap.Map.Tile
{
    public class ScreenCoordinate : IComparable, ICloneable
    {
        public static readonly ScreenCoordinate Empty = new ScreenCoordinate();

        public long X { get;  set; }

        public long Y { get; set; }

        public int Level { get; set; }

        private ScreenCoordinate()
        {
            X = 0;
            Level = 0;
            Y = 0;
        }

        public ScreenCoordinate(long pX, long pY, int pLevel)
        {
            X = pX;
            Y = pY;
            Level = pLevel;
        }

        public ScreenCoordinate(GeomCoordinate coordinate, int level)
        {
            X = MapUtilities.GetX(coordinate, level);
            Y = MapUtilities.GetY(coordinate, level);
            Level = level;
        }

        #region ICloneable Members
        public object Clone()
        {
            return new ScreenCoordinate(X, Y, Level);
        }
        #endregion

        #region IComparable Members
        public int CompareTo(Object obj)
        {
            var coords = (ScreenCoordinate)obj;
            if (coords.Level < Level)
                return -1;
            if (coords.Level > Level)
                return 1;
            if (coords.Y < Y)
                return -1;
            if (coords.Y > Y)
                return 1;
            if (coords.X < X)
                return -1;
            if (coords.X > X)
                return 1;
            return 0;
        }
        #endregion

        public static ScreenCoordinate operator + (ScreenCoordinate Tile, ScreenCoordinate addon)
        {
            if (Tile.Level != addon.Level)
            {
                addon = new ScreenCoordinate(addon, Tile.Level);
            }
            return new ScreenCoordinate(Tile.X + addon.X, Tile.Y + addon.Y, Tile.Level);
        }

        public static implicit operator GeomCoordinate(ScreenCoordinate Tile)
        {
            return new GeomCoordinate(MapUtilities.GetLongitude(Tile), MapUtilities.GetLatitude(Tile));
        }

        public static implicit operator TileBlock(ScreenCoordinate Tile)
        {
            return new TileBlock(
                (int)(Tile.X / TileBlock.BlockSize), 
                (int)(Tile.Y / TileBlock.BlockSize),
                Tile.Level);
        }

        public Point GetScreenPoint(ScreenRectangle screenView)
        {
            if (Level != screenView.Level)
            {
                screenView = new ScreenRectangle(new CoordinateRectangle(screenView.LeftTop, screenView.RightBottom), Level);
            }
            return new Point((int)(X - screenView.Left), (int)(Y - screenView.Top));
        }
    }
}
