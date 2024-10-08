using System;

using ObjLoader.Loader.Common;
using ObjLoader.Loader.Data.DataStore;
using ObjLoader.Loader.Data.VertexData;
using ObjLoader.Loader.TypeParsers.Interfaces;

namespace ObjLoader.Loader.TypeParsers
{
    /// <summary>1.0 0.0 0.0</summary>
    public class VertexParser : TypeParserBase, IVertexParser
    {
        private readonly IVertexDataStore _vertexDataStore;

        public VertexParser(IVertexDataStore vertexDataStore)
        {
            _vertexDataStore = vertexDataStore;
        }

        protected override string Keyword => "v";

        public override void Parse(string line)
        {
            string[] parts = line.Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries);

            var x = parts[0].ParseInvariantFloat();
            var y = parts[1].ParseInvariantFloat();
            var z = parts[2].ParseInvariantFloat();

            var vertex = new Vertex(x, y, z);

            if(parts.Length == 4)
            {
                var w = parts[3].ParseInvariantFloat();
                vertex = new Vertex(x, y, z, w);
            }
            else if (parts.Length == 6)
            {
                var r = parts[3].ParseInvariantFloat();
                var g = parts[4].ParseInvariantFloat();
                var b = parts[5].ParseInvariantFloat();
                vertex = new Vertex(x, y, z, r, g, b);
            }
            else if (parts.Length == 7)
            {
                var r = parts[3].ParseInvariantFloat();
                var g = parts[4].ParseInvariantFloat();
                var b = parts[5].ParseInvariantFloat();
                var a = parts[6].ParseInvariantFloat();
                vertex = new Vertex(x, y, z, r, g, b, a);
            }          
            _vertexDataStore.AddVertex(vertex);
        }
    }
}