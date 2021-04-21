using ProgramMain.Map.Tile;
using ProgramMain.Map.Indexer;
using ProgramMain.Map.Types;

namespace ProgramMain.Map
{
    public class CoordinatePoligon
    {
        public static readonly CoordinatePoligon Empty = new CoordinatePoligon();

        public readonly CoordinateIndexer Coordinates;

        public GeomCoordinate First
        {
            get { return Coordinates[0]; }
        }

        public GeomCoordinate Last
        {
            get { return Coordinates[Coordinates.Count - 1]; }
        }

        public CoordinateRectangle this[int index]
        {
            get
            {
                if (index < 0 || index > Count - 1)
                    return null;
                var leftTop = Coordinates[index];
                var rightBottom = index == Count - 1 ? Coordinates[0] : Coordinates[index + 1];
                return new CoordinateRectangle(leftTop, rightBottom);
            }
        }

        public int Count
        {
            get { return Coordinates.Count; }
        }

        public CoordinatePoligon()
        {
            Coordinates = new CoordinateIndexer();
        }

        public bool Add(GeomCoordinate coordinate)
        {
            if (Count > 2)
            {
                var line1 = new CoordinateRectangle(First, coordinate);
                var line2 = new CoordinateRectangle(Last, coordinate);
                for (var i = 0; i < Count - 1; i++)
                {
                    if (MapUtilities.CheckLinesIntersection(this[i], line1)
                        || MapUtilities.CheckLinesIntersection(this[i], line2))
                        return false;
                }
            }

            Coordinates.Add(coordinate);
            return true;
        }

        public double PoligonDistance(GeomCoordinate coordinate)
        {
            double res = 0;

            for (var i = 0; i < Count; i++)
            {
                var distance = this[i].LineDistance(coordinate);
                if (i == 0 || distance < res)
                    res = distance;
            }
            return res;
        }

        public bool IncludeTo(CoordinateRectangle rect)
        {
            for (var i = 0; i < Coordinates.Count; i++)
            {
                if (rect.PointContains(Coordinates[i]) != IntersectResult.Contains)
                    return false;
            }
            return true;
        }

        public IntersectResult PointContains(GeomCoordinate coordinate)
        {
            //to do

            return IntersectResult.None;
        }

        public IntersectResult LineContains(CoordinateRectangle coordinate)
        {
            //to do

            return IntersectResult.None;
        }

        public IntersectResult RectangleContains(CoordinateRectangle coordinate)
        {
            //to do

            return IntersectResult.None;
        }

        public IntersectResult PoligonContains(CoordinateRectangle coordinate)
        {
            //to do

            return IntersectResult.None;
        }
    }
}
