using System.Data;
using System.Threading.Tasks;

using SimpleMap.Layers.MapObjects.TreeNodes;
using SimpleMap.Map.Spatial;
using SimpleMap.Map.Spatial.Types;
using SimpleMap.SimpleMapDb;

namespace SimpleMap.Layers.MapObjects
{
    public class CableTree : SpatialTree<CableNode>
    {
        public MapDb.CablesDataTable CableDbRows { get; private set; }

        public CableTree()
            : base(SpatialSheetPowerTypes.Ultra, SpatialSheetPowerTypes.High, SpatialSheetPowerTypes.Low, SpatialSheetPowerTypes.Low)
        {
            CableDbRows = new MapDb.CablesDataTable();
        }

        protected void Insert(MapDb.CablesRow row)
        {
            base.Insert(row);
        }

        protected void Delete(MapDb.CablesRow row)
        {
            base.Delete(row);
        }
        
        public void LoadData()
        {
            Clear();

            //read data from db here

            Parallel.ForEach(CableDbRows, Insert);
        }

        public void MergeData(MapDb.CablesDataTable cables)
        {
            if (CableDbRows == null) return;

            CableDbRows.Merge(cables, false, MissingSchemaAction.Error);

            Parallel.ForEach(cables, row =>
            {
                var newRow = CableDbRows.FindByID(row.ID);
                Insert(newRow);
            });

            //apply changes to db here
        }

        public bool RemoveCable(int objectId)
        {
            var row = (CableDbRows == null) ? null : CableDbRows.FindByID(objectId);
            if (row != null)
            {
                Delete(row);

                CableDbRows.Rows.Remove(row);
                //apply changes to db here

                return true;
            }
            return false;
        }

        public MapDb.CablesRow GetCable(int objectId)
        {
            if (CableDbRows == null) return null;

            var row = CableDbRows.FindByID(objectId);
            if (row != null)
            {
                var dt = (MapDb.CablesDataTable)CableDbRows.Clone();
                dt.ImportRow(row);
                return (MapDb.CablesRow)dt.Rows[0];
            }
            return null;
        }
    }
}
