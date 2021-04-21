using System;
using System.Drawing;
using ProgramMain.Map.Tile;
using ProgramMain.Map.Types;

namespace ProgramMain.Map
{
    public class CoordinateRectangle : ICloneable
    {
        public static readonly CoordinateRectangle Empty = new CoordinateRectangle();

        public GeomCoordinate LeftTop
        {
            get
            {
                return new GeomCoordinate(Left, Top);
            }
        }

        public GeomCoordinate RightBottom
        {
            get
            {
                return new GeomCoordinate(Right, Bottom);
            }
        }

        public GeomCoordinate LeftBottom
        {
            get
            {
                return new GeomCoordinate(Left, Bottom);
            }
        }

        public GeomCoordinate RightTop
        {
            get
            {
                return new GeomCoordinate(Right, Top);
            }
        }

        public double Width
        {
            get { return Right - Left; }
        }

        public double Height
        {
            get { return Bottom - Top; }
        }

        public double Left { get; private set; }

        public double Right { get; private set; }

        public double Top { get; private set; }

        public double Bottom { get; private set; }

        private CoordinateRectangle()
        {
            Bottom = 0;
            Top = 0;
            Right = 0;
            Left = 0;
        }

        public CoordinateRectangle(double left, double top, double right, double bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public CoordinateRectangle(decimal left, decimal top, decimal right, decimal bottom)
        {
            Left = (double)left;
            Top = (double)top;
            Right = (double)right;
            Bottom = (double)bottom;
        }

        public CoordinateRectangle(GeomCoordinate pLeftTop, GeomCoordinate pRightBottom)
        {
            Left = pLeftTop.Longitude;
            Top = pLeftTop.Latitude;
            Right = pRightBottom.Longitude;
            Bottom = pRightBottom.Latitude;
        }

        #region ICloneable Members
        public object Clone()
        {
            return new CoordinateRectangle(Left, Top, Right, Bottom);
        }
        #endregion


        public override string ToString()
        {
            return (String.Format("E{0:F5} N{1:F5} - E{2:F5} N{3:F5} : {4:n}m", Left, Top, Right, Bottom, LineLength));
        }

        public Rectangle GetScreenRect(ScreenRectangle screenView)
        {
            return new ScreenRectangle(this, screenView.Level).GetScreenRect(screenView);
        }

        public IntersectResult PointContains(GeomCoordinate point)
        {
            return (point.Longitude >= Left
                && point.Longitude <= Right
                && point.Latitude <= Top
                && point.Latitude >= Bottom) ? IntersectResult.Contains : IntersectResult.None;
        }

        public IntersectResult RectangleContains(CoordinateRectangle rectangle)
        {
            var iLeftTop = PointContains(rectangle.LeftTop) != IntersectResult.None;
            var iRightBottom = PointContains(rectangle.RightBottom) != IntersectResult.None;

            if (iLeftTop && iRightBottom)
                return IntersectResult.Contains;
            if (iLeftTop || iRightBottom)
                return IntersectResult.Intersects;

            if (PointContains(rectangle.LeftBottom) != IntersectResult.None)
                return IntersectResult.Intersects;
            if (PointContains(rectangle.RightTop) != IntersectResult.None)
                return IntersectResult.Intersects;

            iLeftTop = rectangle.PointContains(LeftTop) != IntersectResult.None;
            iRightBottom = rectangle.PointContains(RightBottom) != IntersectResult.None;

            if (iLeftTop && iRightBottom)
                return IntersectResult.Supersets;
            if (iLeftTop || iRightBottom)
                return IntersectResult.Intersects;

            if (rectangle.PointContains(LeftBottom) != IntersectResult.None)
                return IntersectResult.Intersects;
            if (rectangle.PointContains(RightTop) != IntersectResult.None)
                return IntersectResult.Intersects;

            if (MapUtilities.CheckLinesIntersection(new CoordinateRectangle(Left, Top, Left, Bottom),
                    new CoordinateRectangle(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Top)))
                return IntersectResult.Intersects;
            if (MapUtilities.CheckLinesIntersection(new CoordinateRectangle(Left, Top, Right, Top),
                    new CoordinateRectangle(rectangle.Left, rectangle.Top, rectangle.Left, rectangle.Bottom)))
                return IntersectResult.Intersects;

            return IntersectResult.None;
        }

        public IntersectResult LineContains(CoordinateRectangle line)
        {
            var iLeftTop = PointContains(line.LeftTop) != IntersectResult.None;
            var iRightBottom = PointContains(line.RightBottom) != IntersectResult.None;

            if (iLeftTop && iRightBottom)
                return IntersectResult.Contains;
            if (iLeftTop || iRightBottom)
                return IntersectResult.Intersects;
            if (MapUtilities.CheckLinesIntersection(new CoordinateRectangle(Left, Top, Right, Top), line))
                return IntersectResult.Intersects;
            if (MapUtilities.CheckLinesIntersection(new CoordinateRectangle(Right, Top, Right, Bottom), line))
                return IntersectResult.Intersects;
            if (MapUtilities.CheckLinesIntersection(new CoordinateRectangle(Left, Bottom, Right, Bottom), line))
                return IntersectResult.Intersects;
            if (MapUtilities.CheckLinesIntersection(new CoordinateRectangle(Left, Top, Left, Bottom), line))
                return IntersectResult.Intersects;
            return IntersectResult.None;
        }

        public IntersectResult PoligonContains(CoordinatePoligon poligon)
        {
            if (poligon.IncludeTo(this))
                return IntersectResult.Contains;

            for (var i = 0; i < poligon.Count; i++)
            {
                if (LineContains(poligon[i]) != IntersectResult.None)
                    return IntersectResult.Intersects;
            }

            if (poligon.PointContains(LeftTop) != IntersectResult.None
                && poligon.PointContains(RightTop) != IntersectResult.None
                && poligon.PointContains(RightBottom) != IntersectResult.None
                && poligon.PointContains(LeftBottom) != IntersectResult.None)
                return IntersectResult.Supersets;

            return IntersectResult.None;
        }

        public double RectangeDistance(GeomCoordinate coordinate)
        {
            if (PointContains(coordinate) != IntersectResult.None)
                return 0;

            var min = EarthUtilities.GetDistance(new CoordinateRectangle(Left, Top, Right, Top), coordinate);
            var res = EarthUtilities.GetDistance(new CoordinateRectangle(Right, Top, Right, Bottom), coordinate);
            if (res < min) min = res;
            res = EarthUtilities.GetDistance(new CoordinateRectangle(Right, Bottom, Left, Bottom), coordinate);
            if (res < min) min = res;
            res = EarthUtilities.GetDistance(new CoordinateRectangle(Left, Bottom, Left, Top), coordinate);
            if (res < min) min = res;

            return min;
        }

        public double LineDistance(GeomCoordinate coordinate)
        {
            return EarthUtilities.GetDistance(this, coordinate);
        }

        public GeomCoordinate LineMiddlePoint
        {
            get { return MapUtilities.GetMiddlePoint(LeftTop, RightBottom); }
        }

        public double LineLength
        {
            get { return LeftTop.Distance(RightBottom); }
        }

        public double LineAngle
        {
            get { return Math.Atan2(Width, Height); }
        }

        public void LineGrow(double meter)
        {
            var len = LineLength;
            var ang = LineAngle;
            Right = Left + (len + meter) * Math.Cos(ang);
            Bottom = Top + (len + meter) * Math.Sin(ang);
        }

        public GeomCoordinate GetNearestPoint(GeomCoordinate pt)
        {
            return EarthUtilities.GetNearestPoint(this, pt);
        }
    }
}