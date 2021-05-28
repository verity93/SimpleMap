using System.Collections.Generic;

namespace SimpleMap.Map.Indexer
{
    public class CoordinateIndexer
    {
        private List<GeomCoordinate> _values;

        public GeomCoordinate this[int index]
        {
            get { return index >= 0 && index < _values.Count ? _values[index] : null; }
        }

        public int Count {get { return _values != null ? _values.Count : 0; }}
        
        public void Add(GeomCoordinate coordinate)
        {
            if (_values == null)
                _values = new List<GeomCoordinate>();
            _values.Add(coordinate);
        }

        public void Remove(GeomCoordinate coordinate)
        {
            if (_values != null)
            {
                _values.Remove(coordinate);
            }
        }

        public void Destroy()
        {
            if (_values != null)
            {
                _values.Clear();
                _values = null;
            }
        }

        public bool HasChilds
        {
            get { return _values != null && _values.Count > 0; }
        }
    }
}
