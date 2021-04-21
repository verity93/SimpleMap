using System;
using System.Collections.Generic;
using System.Text;
using WildSoft;

namespace Calibration
{
    public class geoReference
    {
        //  instance variables
        protected Array points;
        protected float lat0, long0, delX, delY;

        //  constructor
        public geoReference(Array points) 
        {
            this.points = points;
            delX = (maxLONG().LONG - minLONG().LONG) / (maxLONG().X - minLONG().X);
            delY = (minLAT().LAT - maxLAT().LAT) / (minLAT().Y - maxLAT().Y);
            lat0 = maxLAT().LAT - maxLAT().Y * dY;
            long0 = minLONG().LONG - minLONG().X * dX;
        }

        #region methods

        /// <summary>
        /// Finds the min lat among given points
        /// </summary>
        /// <returns>The minimum Latitude</returns>
        private point minLAT()
        {
            Array.Sort(points, new ObjectComparer("LAT"));
            return (point)points.GetValue(0);
        }

        /// <summary>
        /// Finds the max lat among given points
        /// </summary>
        /// <returns>The maximum Latitude</returns>
        private point maxLAT()
        {
            Array.Sort(points, new ObjectComparer(new string[] { "LAT" }, new bool[] { true }));
            return (point)points.GetValue(0);
        }

        /// <summary>
        /// Finds the min long among given points
        /// </summary>
        /// <returns>The minimum Longitude</returns>
        private point minLONG()
        {
            Array.Sort(points, new ObjectComparer("LONG"));
            return (point)points.GetValue(0);
        }

        /// <summary>
        /// Finds the max long among given points
        /// </summary>
        /// <returns>The maximum Longitude</returns>
        private point maxLONG()
        {
            Array.Sort(points, new ObjectComparer(new string[] { "LONG" }, new bool[] { true }));
            return (point)points.GetValue(0);
        }

        
        /// <summary>
        /// Converts X and Y pixel coordinates to Latitude and Longitude coordinates
        /// </summary>
        /// <param name="X">The X coordinate to convert</param>
        /// <param name="Y">The Y coordinate to convert</param>
        /// <returns>A point object containing the new lat/long of the corresponding x,y coordinates</returns>
        public point XYtoLatLong(float X, float Y)
        {
            float Lat = LAT0 + dY * Y;
            float Long = LONG0 + dX * X;
            point pnt = new point(X, Y, Lat, Long);
            return pnt;
        }

        
        /// <summary>
        /// Converts Latitude and Longitude to X and Y pixels
        /// </summary>
        /// <param name="Lat">The Latitude to convert</param>
        /// <param name="Long">The Longitude to convert</param>
        /// <returns>A point object containing the new x,y coordinates of the corresponding lat/long</returns>
        public point LatLongtoXY(float Lat, float Long) 
        {
            float X = (Long - LONG0) / dX;
            float Y = (Lat - LAT0) / dY;
            point pnt = new point(X, Y, Lat, Long);
            return pnt;
        }

        #endregion
        #region properties

        public float LAT0
        {
            get {return lat0;}
        }

        public float LONG0
        {
            get { return long0; }
        }

        public float dX
	    {
	    	get { return delX;}
	    }

        public float dY
        {
            get { return delY; }
        }
#endregion

        #region class point
        /// <summary>
        /// class point that encapsulates the x,y,lat and long information
        /// </summary>
        public class point
        {
            //  constructor
            public point(float x, float y, float Lat, float Long)
            {
                this.x = x;
                this.y = y;
                this.Lat = Lat;
                this.Long = Long;

            }

            #region properties

            public float X
            {
                get { return this.x; }
                set { this.x = value; }
            }private float x;

            public float Y
            {
                get { return this.y; }
                set { this.y = value; }
            }private float y;

            public float LAT
            {
                get { return this.Lat; }
                set { this.Lat = value; }
            }private float Lat;

            public float LONG
            {
                get { return this.Long; }
                set { this.Long = value; }
            }private float Long;

            #endregion
        }
        #endregion
    }
}
