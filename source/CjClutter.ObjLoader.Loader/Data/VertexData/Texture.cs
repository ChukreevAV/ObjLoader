using ObjLoader.Loader.Common;

namespace ObjLoader.Loader.Data.VertexData
{
    public struct Texture
    {
        public Texture(float u, float v = 0, float w = 0) : this()
        {
            U = u;
            V = v;
            W = w;
        }

        public float U { get; private set; }

        public float V { get; private set; }

        public float W { get; private set; }

        public readonly override string ToString()
        {
            var str = $"vt {U.FloatToStr()}";

            if (V > 0 | W > 0) str += $" {V.FloatToStr()}";

            if (W > 0) str += $" {W.FloatToStr()}";

            return str;
        }
    }
}