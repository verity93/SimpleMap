using System;

namespace SimpleMap.Map
{
    internal class EarthUtilities
    {

        #region Auxiliary functions for calculating distances for the globe with the assumption that all objects are at a height of 0 meters above sea level

        /// <summary>
        /// Approximate distance between two points
        /// Transmitted latitude / longitude in degrees and hundredths
        /// </summary>
        public static double GetLength(GeomCoordinate c1, GeomCoordinate c2)
        {

            // Constants used to calculate offset and distance
            const double d2R = Math.PI / 180; // Constant to convert degrees to radians
            const double a = 6378137.0; // Main axis
            // const double b = 6356752.314245; // Minor axis
            const double e2 = 0.006739496742337; // The square of the eccentricity of the ellipsoid

            // Calculate the difference between two longitudes and latitudes and get the average latitude
            var fdLambda = (c1.Longitude - c2.Longitude) * d2R; // The difference between the two values ​​of longitude
            var fdPhi = (c1.Latitude - c2.Latitude) * d2R; // The difference between the two latitudes
            var fPhimean = ((c1.Latitude + c2.Latitude) / 2.0) * d2R; // Mid latitude

            // Meridian radius of curvature
            var fRho = (a * (1 - e2)) / Math.Pow(1 - e2 * (Math.Pow(Math.Sin(fPhimean), 2)), 1.5);
            // Transverse radius of curvature
            var fNu = a / (Math.Sqrt(1 - e2 * (Math.Sin(fPhimean) * Math.Sin(fPhimean))));

            // Calculate the angular distance from the center of the spheroid
            var fz = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(fdPhi / 2.0), 2) + Math.Cos(c2.Latitude * d2R) * Math.Cos(c1.Latitude * d2R) * Math.Pow(Math.Sin(fdLambda / 2.0), 2)));

            // Calculate the offset
            var fAlpha = Math.Asin(Math.Cos(c2.Latitude * d2R) * Math.Sin(fdLambda) * 1 / Math.Sin(fz));
            // Calculate the radius of the Earth
            var fR = (fRho * fNu) / ((fRho * Math.Pow(Math.Sin(fAlpha), 2)) + (fNu * Math.Pow(Math.Cos(fAlpha), 2)));

            // Calculated distance in meters
            var distance = fz * fR;

            return distance;
        }

        /// <summary>
        /// Approximate distance from point to line segment
        /// Transmitted latitude / longitude in degrees and hundredths
        /// </summary>
        /// 
        public static double GetDistance(CoordinateRectangle line, GeomCoordinate pt)
        {
            const double r2D = 180 / Math.PI; // Constant for converting radians to degrees

            var a = GetLength(line.LeftTop, line.RightBottom);

            var b = GetLength(line.LeftTop, pt);
            var c = GetLength(line.RightBottom, pt);
            if (a <= 0)
                return (b + c) / 2;

            var enB = Math.Acos((Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / (2 * a * b)) * r2D;
            if (enB >= 90)
                return b;
            var enC = Math.Acos((Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) / (2 * a * c)) * r2D;
            if (enC >= 90)
                return c;

            var s = (a + b + c) / 2;
            var ar = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return ar * 2 / a;
        }

        public static GeomCoordinate GetNearestPoint(CoordinateRectangle line, GeomCoordinate pt)
        {

            const double r2D = 180 / Math.PI; // Constant for converting radians to degrees

            var a = GetLength(line.LeftTop, line.RightBottom);
            if (a <= 0)
                return pt;

            var b = GetLength(line.LeftTop, pt);
            var c = GetLength(line.RightBottom, pt);

            var enB = Math.Acos((Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / (2 * a * b)) * r2D;
            if (enB >= 90)
                return pt;
            var enC = Math.Acos((Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) / (2 * a * c)) * r2D;
            if (enC >= 90)
                return pt;


            var x = ((line.Right - line.Left) * (line.Bottom - line.Top) * (pt.Latitude - line.Top) +
                        line.Left * Math.Pow(line.Bottom - line.Top, 2) + pt.Longitude * Math.Pow(line.Right - line.Left, 2)) /
                       (Math.Pow(line.Bottom - line.Top, 2) + Math.Pow(line.Right - line.Left, 2));
            var y = (line.Bottom - line.Top) * (x - line.Left) / (line.Right - line.Left) + line.Top;

            return new GeomCoordinate(x, y);
        }

        #endregion
    }
}
