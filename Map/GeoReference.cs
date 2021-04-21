using System;
using System.Collections.Generic;
using System.Text;


public class geoReference
{
    // image overlays unprojected with lat/long extents


    //  instance variables
    protected Array points;
    protected float lat0, long0, delX, delY;

    //  constructor
    public geoReference(Array points)
    {
        //this.points = points;
        //delX = (maxLONG().LONG - minLONG().LONG) / (maxLONG().X - minLONG().X);
        //delY = (minLAT().LAT - maxLAT().LAT) / (minLAT().Y - maxLAT().Y);
        //lat0 = maxLAT().LAT - maxLAT().Y * dY;
        //long0 = minLONG().LONG - minLONG().X * dX;
    }

}

