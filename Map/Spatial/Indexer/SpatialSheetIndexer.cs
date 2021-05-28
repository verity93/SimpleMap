using System.Collections.Generic;
using SimpleMap.Map.Tile;
using SimpleMap.Map.Spatial.Types;

namespace SimpleMap.Map.Spatial.Indexer
{
    internal class SpatialSheetIndexer<TNode> where TNode : ISpatialTreeNode
    {
        private readonly SpatialTree<TNode> _tree;
        private readonly SpatialSheetBase<TNode> _sheet;

        private SortedDictionary<TileBlock, SpatialSheet<TNode>> _children;

        internal SpatialSheetIndexer(SpatialSheetBase<TNode> sheet, SpatialTree<TNode> tree)
        {
            _tree = tree;
            _sheet = sheet;
        }

        public SpatialSheetPowerTypes Power(int level)
        {
            return _tree.Power[level];
        }

        public int PowerLength
        {
            get { return _tree.Power.Length; }
        }

        public SpatialSheet<TNode> this[TileBlock block]
        {
            get
            {
                SpatialSheet<TNode> sheet;

                if (_children == null)
                    _children = new SortedDictionary<TileBlock, SpatialSheet<TNode>>();

                if (!_children.TryGetValue(block, out sheet))
                {
                    //нужен для тюнинга индекса, содержит количество ветвей индекса на каждом уровне
                    if (_sheet.Level > 0 && _sheet.Level <= _tree.NodeDimension.Length)
                        _tree.NodeDimension[_sheet.Level - 1]++;

                    sheet = new SpatialSheet<TNode>(
                        _tree,
                        _sheet.Level + 1,
                        _sheet.NextTileLevel,
                        (ScreenRectangle) block);
                    _children.Add(block, sheet);
                }
                return sheet;
            }
        }

        public SortedDictionary<TileBlock, SpatialSheet<TNode>>.ValueCollection Values
        {
            get { return _children != null ? _children.Values : null; }
        }

        public void Remove(TileBlock block)
        {
            if (_children != null)
            {
                //нужен для тюнинга индекса, содержит количество ветвей индекса на каждом уровне
                _tree.NodeDimension[_sheet.Level - 1]--;

                _children.Remove(block);
            }
        }

        public void Destroy()
        {
            _children.Clear();
            _children = null;
        }

        public bool HasChilds
        {
            get { return _children != null && _children.Count > 0; }
        }
    }
}
