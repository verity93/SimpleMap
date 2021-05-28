using System;
using System.Data;

using SimpleMap.Map;
using SimpleMap.Map.Spatial.Types;
using SimpleMap.SimpleMapDb;

namespace SimpleMap.Layers.MapObjects.TreeNodes
{
    public class CableNode : ISpatialTreeNode
    {
        private readonly MapDb.CablesRow _row;

        public SpatialTreeNodeTypes NodeType
        {
            get { return SpatialTreeNodeTypes.Line; }
        }

        public GeomCoordinate Coordinate
        {
            get { throw new Exception(); }
        }

        public CoordinateRectangle Rectangle
        {
            get
            {
                return new CoordinateRectangle(
                    _row.Longitude1,
                    _row.Latitude1,
                    _row.Longitude2,
                    _row.Latitude2);
            }
        }

        public CoordinatePoligon Poligon
        {
            get { throw new Exception(); }
        }

        public int RowId
        {
            get { return _row.ID; }
        }

        internal CableNode(MapDb.CablesRow row)
        {
            _row = row;    
        }

        public DataRow Row
        {
            get { return _row; }
        }

        public static implicit operator CableNode(MapDb.CablesRow row)
        {
            return new CableNode(row);
        }
    }
}