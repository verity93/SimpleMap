using System.Data;
using System.Threading.Tasks;

using SimpleMap.Layers.MapObjects.TreeNodes;
using SimpleMap.Map.Spatial;
using SimpleMap.Map.Spatial.Types;
using SimpleMap.SimpleMapDb;

namespace SimpleMap.Layers.MapObjects
{
    public class VertexTree : SpatialTree<VertexNode>
    {
        public MapDb.VertexesDataTable VertexDbRows { get; private set;}

        public VertexTree()
            : base(SpatialSheetPowerTypes.Ultra, SpatialSheetPowerTypes.Extra, SpatialSheetPowerTypes.Medium, SpatialSheetPowerTypes.Low)
        {
            VertexDbRows = new MapDb.VertexesDataTable();
        }

        protected void Insert(MapDb.VertexesRow row)
        {
            base.Insert(row);
        }

        protected void Delete(MapDb.VertexesRow row)
        {
            base.Delete(row);
        }

        public void LoadData()
        {
            Clear();

            //read data from db here

            Parallel.ForEach(VertexDbRows, Insert);
        }

        public void MergeData(MapDb.VertexesDataTable vertexes)
        {
            if (VertexDbRows == null) return;

            VertexDbRows.Merge(vertexes, false, MissingSchemaAction.Error);

            Parallel.ForEach(vertexes, row =>
            {
                var newRow = VertexDbRows.FindByID(row.ID);
                Insert(newRow);
            });

            //apply changes to db here
        }

        public bool RemoveVertex(int objectId)
        {
            var row = (VertexDbRows == null) ? null : VertexDbRows.FindByID(objectId);
            if (row != null)
            {
                Delete(row);

                VertexDbRows.Rows.Remove(row);
                //apply changes to db here

                return true;
            }
            return false;
        }

        public MapDb.VertexesRow GetVertex(int objectId)
        {
            if (VertexDbRows == null) return null;

            var row = VertexDbRows.FindByID(objectId);
            if (row != null)
            {
                var dt = (MapDb.VertexesDataTable)VertexDbRows.Clone();
                dt.ImportRow(row);
                return (MapDb.VertexesRow)dt.Rows[0];
            }
            return null;
        }
    }
}
