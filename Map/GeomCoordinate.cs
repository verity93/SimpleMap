using System;
using System.Drawing;
using ProgramMain.Map.Tile;

namespace ProgramMain.Map
{
    public class GeomCoordinate : IComparable, ICloneable
    {
       

        public static readonly GeomCoordinate Empty = new GeomCoordinate();

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        private GeomCoordinate()
        {
            Latitude = 0;
            Longitude = 0;
        }

       
        public GeomCoordinate(double pLongitude, double pLatitude)
        {
            Longitude = pLongitude;
            Latitude = pLatitude;
        }

        public GeomCoordinate(decimal pLongitude, decimal pLatitude)
        {
            Longitude = (double)pLongitude;
            Latitude = (double)pLatitude;
        }

        #region ICloneable Members
        public object Clone()
        {
            return new GeomCoordinate(Longitude, Latitude);
        }
        #endregion

        #region IComparable Members
        public int CompareTo(Object obj)
        {
            var coords = (GeomCoordinate)obj;
            if (coords.Latitude < Latitude)
                return -1;
            if (coords.Latitude > Latitude)
                return 1;
            if (coords.Longitude < Longitude)
                return -1;
            if (coords.Longitude > Longitude)
                return 1;
            return 0;
        }
        #endregion


        public override string ToString()
        {
            return (String.Format("E{0:F5} N{1:F5}", Longitude, Latitude));
        }

        public static GeomCoordinate operator + (GeomCoordinate coordinate, ScreenCoordinate addon)
        {
            return new ScreenCoordinate(coordinate, addon.Level) + addon;
        }
        
        private ScreenCoordinate GetLeftTop(int screenWidth, int screenHeight, int level)
        {
            return new ScreenCoordinate(
                MapUtilities.GetX(this, level) - ((screenWidth + 1) / 2 - 1),
                MapUtilities.GetY(this, level) - ((screenHeight + 1) / 2 - 1),
                level);
        }

        private ScreenCoordinate GetRightBottom(int screenWidth, int screenHeight, int level)
        {
            return new ScreenCoordinate(
                MapUtilities.GetX(this, level) + ((screenWidth - 1) / 2 + 1),
                MapUtilities.GetY(this, level) + ((screenHeight - 1) / 2 + 1),
                level);
        }

        public ScreenRectangle GetScreenViewFromCenter(int screenWidth, int screenHeight, int level)
        {
            return new ScreenRectangle(GetLeftTop(screenWidth, screenHeight, level), GetRightBottom(screenWidth, screenHeight, level));
        }

        public Point GetScreenPoint(ScreenRectangle screenView)
        {
            return new ScreenCoordinate(this, screenView.Level).GetScreenPoint(screenView);
        }

        public static GeomCoordinate GetCoordinateFromScreen(ScreenRectangle screenView, Point point)
        {
            return screenView.LeftTop + new ScreenCoordinate(point.X, point.Y, screenView.Level);
        }

        public TileBlock GetTileBlock(int level)
        {
            return new ScreenCoordinate(this, level);
        }

        public double Distance(GeomCoordinate coordinate)
        {
            return EarthUtilities.GetLength(this, coordinate);
        }
    }
}
