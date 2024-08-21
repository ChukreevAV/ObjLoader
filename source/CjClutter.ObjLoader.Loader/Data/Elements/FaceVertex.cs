using ObjLoader.Loader.Common;

namespace ObjLoader.Loader.Data.Elements
{
    public struct FaceVertex
    {
        public FaceVertex(int vertexIndex, int textureIndex, int normalIndex) : this()
        {
            VertexIndex = vertexIndex;
            TextureIndex = textureIndex;
            NormalIndex = normalIndex;
        }

        public int VertexIndex { get; set; }

        public int TextureIndex { get; set; }

        public int NormalIndex { get; set; }

        public readonly string ToStr()
        {
            var str = VertexIndex.IntToStr();

            if (NormalIndex > 0)
            {
                str += $"/{(TextureIndex > 0? TextureIndex.IntToStr() : string.Empty)}/{(NormalIndex > 0 ? NormalIndex.IntToStr() : string.Empty)}";
            }

            return str;
        }
    }
}