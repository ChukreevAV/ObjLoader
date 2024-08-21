using ObjLoader.Loader.Common;

namespace CjClutter.ObjLoader.Loader.Data.VertexData
{
    public struct VertexParameter
    {
        public VertexParameter(float u, float v = 0, float w = 1) : this()
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
            var str = $"vp {U.FloatToStr()} {V.FloatToStr()}";

            if (W > 1) str += $" {W.FloatToStr()}";

            return str;
        }
    }
}