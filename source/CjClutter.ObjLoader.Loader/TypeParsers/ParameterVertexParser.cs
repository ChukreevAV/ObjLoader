using CjClutter.ObjLoader.Loader.Data.VertexData;
using CjClutter.ObjLoader.Loader.TypeParsers.Interfaces;

using ObjLoader.Loader.Common;
using ObjLoader.Loader.Data.DataStore;
using ObjLoader.Loader.TypeParsers;

namespace CjClutter.ObjLoader.Loader.TypeParsers
{
    public class ParameterVertexParser : TypeParserBase, IParameterVertexParser
    {
        private readonly IVertexDataStore _vertexDataStore;

        public ParameterVertexParser(IVertexDataStore vertexDataStore)
        {
            _vertexDataStore = vertexDataStore;
        }

        protected override string Keyword => "vp";

        public override void Parse(string line)
        {
            string[] parts = line.Split(' ');

            float u = parts[0].ParseInvariantFloat();
            float v = parts[1].ParseInvariantFloat();

            var texture = new VertexParameter(u, v);

            if (parts.Length > 2)
            {
                float w = parts[2].ParseInvariantFloat();
                texture = new VertexParameter(u, v, w);
            }

            _vertexDataStore.AddParameterVertex(texture);
        }
    }
}