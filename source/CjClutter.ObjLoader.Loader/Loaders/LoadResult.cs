using System.Collections.Generic;
using System.Text;

using ObjLoader.Loader.Data;
using ObjLoader.Loader.Data.Elements;
using ObjLoader.Loader.Data.VertexData;

namespace ObjLoader.Loader.Loaders
{
    public class LoadResult
    {
        public IList<Vertex> Vertices { get; set; }

        public IList<Texture> Textures { get; set; }

        public IList<Normal> Normals { get; set; }

        public IList<Group> Groups { get; set; }

        public IList<string> Mtllibs { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var v in Vertices)
            {
                sb.AppendLine(v.ToString());
            }

            foreach (var t in Textures)
            {
                sb.AppendLine(t.ToString());
            }

            foreach (var n in Normals)
            {
                sb.AppendLine(n.ToString());
            }

            return string.Empty;
        }
    }

    public class LoadResultMtl 
    {
        public IList<Material> Materials { get; set; }
    }
}