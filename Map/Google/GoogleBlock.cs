using System;
using System.Drawing;

namespace ProgramMain.Map.Tile
{
    public class TileBlock : IComparable, ICloneable
    {
        public static readonly TileBlock Empty = new TileBlock();

        public const int BlockSize = 256;

        public Point Pt
        {
            get
            {
                return new Point(X, Y);
            }
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public int Level { get; private set; }

        private TileBlock()
        {
            Level = 0;
            Y = 0;
            X = 0;
        }

        public TileBlock(int pX, int pY, int pLevel)
        {
            X = pX;
            Y = pY;
            Level = pLevel;
        }

        public TileBlock(Point pt, int pLevel)
        {
            X = pt.X;
            Y = pt.Y;

            Level = pLevel;
        }

        #region ICloneable Members
        public object Clone()
        {
            return new TileBlock(X, Y, Level);
        }
        #endregion

        #region IComparable Members
        public int CompareTo(Object obj)
        {
            var coords = (TileBlock)obj;
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

        public static implicit operator ScreenCoordinate(TileBlock block)
        {
            return new ScreenCoordinate(block.X * BlockSize, block.Y * BlockSize, block.Level);
        }

        public static implicit operator ScreenRectangle(TileBlock block)
        {
            return new ScreenRectangle(
                block.X * BlockSize, block.Y * BlockSize,
                (block.X + 1) * BlockSize, (block.Y + 1) * BlockSize,
                block.Level);
        }
    }
}
