using ObjLoader.Loader.Common;

namespace ObjLoader.Loader.Data.VertexData
{
    public struct Normal
    {
        public Normal(float x, float y, float z) : this()
        {
            I = x;
            J = y;
            K = z;
        }

        public float I { get; private set; }

        public float J { get; private set; }

        public float K { get; private set; }

        public readonly override string ToString()
            => $"vn {I.FloatToStr()} {J.FloatToStr()} {K.FloatToStr()}";
    }
}