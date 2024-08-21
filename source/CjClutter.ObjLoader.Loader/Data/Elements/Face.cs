using System.Collections.Generic;

namespace ObjLoader.Loader.Data.Elements
{
    public class Face
    {
        private readonly List<FaceVertex> _vertices = new List<FaceVertex>();

        public void AddVertex(FaceVertex vertex) => _vertices.Add(vertex);

        public FaceVertex this[int i] => _vertices[i];

        public int Count => _vertices.Count;

        public override string ToString()
        {
            var str = "f";

            foreach (var v in _vertices)
            {
                str += $" {v.ToStr()}";
            }

            return str;
        }
    }
}