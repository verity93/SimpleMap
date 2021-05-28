using System.Data;
using System.Threading.Tasks;
using SimpleMap.Layers.MapObjects.TreeNodes;
using SimpleMap.Map.Spatial;
using SimpleMap.Map.Spatial.Types;
using SimpleMap.SimpleMapDb;

namespace SimpleMap.Layers.MapObjects
{
    public class BuildingTree : SpatialTree<BuildingNode>
    {
        public MapDb.BuildingsDataTable BuildingDbRows { get; private set; }

        public BuildingTree()
            : base(SpatialSheetPowerTypes.Ultra, SpatialSheetPowerTypes.Extra, SpatialSheetPowerTypes.Medium, SpatialSheetPowerTypes.Low)
        {
            BuildingDbRows = new MapDb.BuildingsDataTable();
        }

        protected void Insert(MapDb.BuildingsRow row)
        {
            base.Insert(row);
        }

        protected void Delete(MapDb.BuildingsRow row)
        {
            base.Delete(row);
        }
        
        public void LoadData()
        {
            Clear();
            
            //read data from db here

            Parallel.ForEach(BuildingDbRows, Insert);
        }

        public void MergeData(MapDb.BuildingsDataTable buildings)
        {
            if (BuildingDbRows == null) return;

            BuildingDbRows.Merge(buildings, false, MissingSchemaAction.Error);

            Parallel.ForEach(buildings, row =>
            {
                var newRow = BuildingDbRows.FindByID(row.ID);
                Insert(newRow);
            });
            //apply changes to db here
        }

        public bool RemoveBuilding(int objectId)
        {
            var row = (BuildingDbRows == null) ? null : BuildingDbRows.FindByID(objectId);
            if (row != null)
            {
                Delete(row);

                BuildingDbRows.Rows.Remove(row);
                //apply changes to db here

                return true;
            }
            return false;
        }

        public MapDb.BuildingsRow GetBuilding(int objectId)
        {
            if (BuildingDbRows == null) return null;

            var row = BuildingDbRows.FindByID(objectId);
            if (row != null)
            {
                var dt = (MapDb.BuildingsDataTable)BuildingDbRows.Clone();
                dt.ImportRow(row);
                return (MapDb.BuildingsRow)dt.Rows[0];
            }
            return null;
        }
    }
}
