using SimpleMap.Map.Tile;
using SimpleMap.Map.Spatial.Indexer;
using SimpleMap.Map.Spatial.Types;

namespace SimpleMap.Map.Spatial
{
    internal class SpatialSheetBase<TNode> where TNode : ISpatialTreeNode
    {
        public int Level { get; private set; }
        public int TileLevel { get; private set; }

        //Daughter index sheets
        public readonly SpatialSheetIndexer<TNode> Sheets;

        //Content array of index elemets on bottom index sheets
        public readonly SpatialContentIndexer<TNode> Content;

        public bool IsEmpty
        {
            get
            {
                return !Sheets.HasChilds && !Content.HasChilds;
            }
        }

        public bool IsBottomSheet
        {
            get { return Level >= Sheets.PowerLength; }
        }

        public SpatialSheetBase(SpatialTree<TNode> tree, int level, int TileLevel)
        {
            Level = level;
            TileLevel = TileLevel;

            Sheets = new SpatialSheetIndexer<TNode>(this, tree);
            Content = new SpatialContentIndexer<TNode>();
        }

        private int TileNumLevel(int level)
        {
            return (int)MapUtilities.NumLevel((int)Sheets.Power(level));
        }

        private int TileNextLevelAddon()
        {
            return TileNumLevel(Level) - 1;
        }

        public int NextTileLevel
        {
            get { return TileLevel + TileNextLevelAddon(); }
        }

        public void Clear()
        {
            lock (this)
            {
                if (!IsBottomSheet)
                {
                    if (Sheets.HasChilds)
                    {
                        foreach (var sheet in Sheets.Values)
                        {
                            sheet.Clear();
                        }
                        Sheets.Destroy();
                    }
                }
                else
                {
                    Content.Destroy();
                }
            }
        }
    }
}