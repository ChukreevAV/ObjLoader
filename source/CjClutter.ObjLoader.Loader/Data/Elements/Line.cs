using System.Collections.Generic;

namespace ObjLoader.Loader.Data.Elements
{
    public class Line
    {
        private readonly List<int> _indexes = new List<int>();

        public void AddIndexes(int[] Indexes) => _indexes.AddRange(Indexes);

        public int this[int i] => _indexes[i];

        public int Count => _indexes.Count;
    }
}