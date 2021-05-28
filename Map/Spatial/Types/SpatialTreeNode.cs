using System.Data;

namespace SimpleMap.Map.Spatial.Types
{
    public interface ISpatialTreeNode
    {
        SpatialTreeNodeTypes NodeType { get; }
        GeomCoordinate Coordinate { get; }
        CoordinateRectangle Rectangle { get; }
        CoordinatePoligon Poligon { get; }
        int RowId { get; }
        DataRow Row { get; } //!!!absolute
    }
}
