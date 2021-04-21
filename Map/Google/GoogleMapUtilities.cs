using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ProgramMain.Map.Tile
{
    internal class MapUtilities
    {
        #region Helpers to work with Tile Coordinate system
        /// <summary>
        /// Block count on the side of Tile level
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static long NumTiles(int level)
        {
            return Convert.ToInt64(Math.Pow(2, (level - 1)));
        }

        /// <summary>
        /// Block count on the Tile level
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static long CountTiles(int level)
        {
            var numTiles = NumTiles(level);
            return numTiles * numTiles;
        }

        /// <summary>
        /// Translate block count to Tile level
        /// </summary>
        /// <param name="countTiles"></param>
        /// <returns></returns>
        public static long NumLevel(int countTiles)
        {
            return Convert.ToInt64(Math.Log(Math.Sqrt(countTiles), 2)) + 1;
        }

        /// <summary>
        /// Pixel count on the side of Tile level bitmap
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static long BitMapSize(int level)
        {
            return NumTiles(level) * TileBlock.BlockSize;
        }

        /// <summary>
        /// Pixel count on the Tile level bitmap 
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static long BitmapOrigo(int level)
        {
            return BitMapSize(level) / 2;
        }

        /// <summary>
        /// Pixel count per degree on the Tile level bitmap
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static double PixelsPerDegree(int level)
        {
            return (double)BitMapSize(level) / 360;
        }

        /// <summary>
        /// Pixel count per radian on the Tile level bitmap
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static double PixelsPerRadian(int level)
        {
            const double p2 = 2 * Math.PI;
            return BitMapSize(level) / p2;
        }

        /// <summary>
        /// Translate longitude to X coordinate of the Tile level bitmap
        /// </summary>
        public static long GetX(GeomCoordinate coordinate, int level)
        {
            return (long)(Math.Floor(BitmapOrigo(level) + coordinate.Longitude * PixelsPerDegree(level)));
        }

        /// <summary>
        /// Translate latitude to Y coordinate of the Tile level bitmap
        /// </summary>
        public static long GetY(GeomCoordinate coordinate, int level)
        {
            const double d2R = Math.PI / 180;
            var z = (1 + Math.Sin(coordinate.Latitude * d2R)) / (1 - Math.Sin(coordinate.Latitude * d2R));
            return (long)(Math.Floor(BitmapOrigo(level) - 0.5 * Math.Log(z) * PixelsPerRadian(level)));
        }

        /// <summary>
        /// Translate X coordinate of the Tile level bitmap to longitude
        /// </summary>
        public static double GetLongitude(ScreenCoordinate Tile)
        {
            return Math.Round((Tile.X - BitmapOrigo(Tile.Level)) / PixelsPerDegree(Tile.Level), 5);
        }

        /// <summary>
        /// Translate Y coordinate of the Tile level bitmap to latitude
        /// </summary>
        public static double GetLatitude(ScreenCoordinate Tile)
        {
            const double r2D = 180 / Math.PI; 
            const double p2 = Math.PI / 2;
            var z = (Tile.Y - BitmapOrigo(Tile.Level)) / (-1 * PixelsPerRadian(Tile.Level));
            return Math.Round((2 * Math.Atan(Math.Exp(z)) - p2) * r2D, 5);
        }

        /// <summary>
        /// Get Tile bitmap block number X by longitude
        /// </summary>
        public static long GetNumBlockX(GeomCoordinate coordinate, int level)
        {
            return (long)Math.Floor((double)GetX(coordinate, level) / TileBlock.BlockSize);
        }

        /// <summary>
        /// Get Tile bitmap block number Y by latitude
        /// </summary>
        public static long GetNumBlockY(GeomCoordinate coordinate, int level)
        {
            return (long)Math.Floor((double)GetY(coordinate, level) / TileBlock.BlockSize);
        }
        #endregion

        /// <summary>
        /// Line cross
        /// </summary>
        public static bool CheckLinesIntersection(CoordinateRectangle line1, CoordinateRectangle line2)
        {
            double d = (line1.Left - line1.Right) * (line2.Bottom - line2.Top) - (line1.Top - line1.Bottom) * (line2.Right - line2.Left);

            if (Math.Abs(d) < 0.000000001)
                return false;

            double da = (line1.Left - line2.Left) * (line2.Bottom - line2.Top) - (line1.Top - line2.Top) * (line2.Right - line2.Left);
            double db = (line1.Left - line1.Right) * (line1.Top - line2.Top) - (line1.Top - line1.Bottom) * (line1.Left - line2.Left);

            double ta = da / d;
            double tb = db / d;

            return ((0 <= ta) && (ta <= 1) && (0 <= tb) && (tb <= 1));
        }

        /*

        public static GeomCoordinate GetCentralGeoCoordinate(GeomCoordinate posA, GeomCoordinate posB) //IList<GeomCoordinate> geoCoordinates)
        {
            IList<GeomCoordinate> geoCoordinates = new List<GeomCoordinate>
            {
                posA,
                posB
            };

            //if (geoCoordinates.Count == 1)
            //{
            //    return geoCoordinates.Single();
            //}

            double x = 0;
            double y = 0;
            double z = 0;
            foreach (var geoCoordinate in geoCoordinates)
            {
                var latitude = geoCoordinate.Latitude * Math.PI / 180;
                var longitude = geoCoordinate.Longitude * Math.PI / 180;
                x += Math.Cos(latitude) * Math.Cos(longitude);
                y += Math.Cos(latitude) * Math.Sin(longitude);
                z += Math.Sin(latitude);
            }
            var total = geoCoordinates.Count;
            x = x / total;
            y = y / total;
            z = z / total;
            var centralLongitude = Math.Atan2(y, x);
            var centralSquareRoot = Math.Sqrt(x * x + y * y);
            var centralLatitude = Math.Atan2(z, centralSquareRoot);
            return new GeomCoordinate(centralLatitude * 180 / Math.PI, centralLongitude * 180 / Math.PI);
        }
        public static GeomCoordinate MidPoint(GeomCoordinate posA, GeomCoordinate posB)
        {
            GeomCoordinate midPoint = new GeomCoordinate(0d,0d);

            double dLon = DegreesToRadians(posB.Longitude - posA.Longitude);
            double Bx = Math.Cos(DegreesToRadians(posB.Latitude)) * Math.Cos(dLon);
            double By = Math.Cos(DegreesToRadians(posB.Latitude)) * Math.Sin(dLon);

            midPoint.Latitude = RadiansToDegrees(Math.Atan2(
                         Math.Sin(DegreesToRadians(posA.Latitude)) + Math.Sin(DegreesToRadians(posB.Latitude)),
                         Math.Sqrt(
                             (Math.Cos(DegreesToRadians(posA.Latitude)) + Bx) *
                             (Math.Cos(DegreesToRadians(posA.Latitude)) + Bx) + By * By)));

            midPoint.Longitude = posA.Longitude + RadiansToDegrees(Math.Atan2(By, Math.Cos(DegreesToRadians(posA.Latitude)) + Bx));

            return midPoint;
        }

        private static double DegreesToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public static double RadiansToDegrees(double radians)
        {
            double degrees = (180 / Math.PI) * radians;
            return (degrees);
        }
        */

        /// <summary>
        /// Line middle point
        /// </summary>
        public static GeomCoordinate GetMiddlePoint(GeomCoordinate c1, GeomCoordinate c2)
        {
           
            const double d2R = Math.PI / 180;
            const double r2D = 180 / Math.PI; 

            var dLon = d2R * (c2.Longitude - c1.Longitude);
            var c1Rlat = d2R * (c1.Latitude);
            var c2Rlat = d2R * (c2.Latitude);
            var bX = Math.Cos(c2Rlat) * Math.Cos(dLon);
            var bY = Math.Cos(c2Rlat) * Math.Sin(dLon);

            var longitude = Math.Round(c1.Longitude + r2D * (Math.Atan2(bY, Math.Cos(c1Rlat) + bX)), 5);
            var latitude = Math.Round(r2D * (Math.Atan2(Math.Sin(c1Rlat) + Math.Sin(c2Rlat), Math.Sqrt((Math.Cos(c1Rlat) + bX) * (Math.Cos(c1Rlat) + bX) + bY * bY))), 5);

            return new GeomCoordinate(longitude, latitude);
        }

        /// <summary>
        /// Create Url to get bitmap block from Tile bitmap cache
        /// </summary>
        public static string CreateUrl(TileBlock block)
        {
            //GoogleTileUrl =  @"http://mt1.google.com/vt/lyrs=m@146&hl=en&x={0}&y={1}&z={2}";
            return String.Format(Properties.Settings.Default.TileUrl, block.X, block.Y, block.Level - 1);
        }

        /// <summary>
        /// Create web request to get bitmap block from Tile bitmap cache
        /// </summary>
        public static HttpWebRequest CreateTileWebRequest(TileBlock block)
        {
            var urlTile = CreateUrl(block);
            var oRequest = (HttpWebRequest)WebRequest.Create(urlTile);
            oRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)"; //!!!must have browser type to retrieve image from Tile
            return oRequest;
        }
    }
}
