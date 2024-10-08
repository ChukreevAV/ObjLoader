using ObjLoader.Loader.Common;

namespace ObjLoader.Loader.Data.VertexData
{
    public struct Vertex
    {
        public Vertex(float x, float y, float z, float w = 1) : this()
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
            R = 1;
            G = 1;
            B = 1;
            A = 1;
        }

        public Vertex(float x, float y, float z, float r, float g, float b, float a = 1) : this()
        {
            X = x;
            Y = y;
            Z = z;
            W = 1;
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public float X { get; private set; }

        public float Y { get; private set; }

        public float Z { get; private set; }

        public float W { get; private set; }

        public float R { get; private set; }

        public float G { get; private set; }

        public float B { get; private set; }

        public float A { get; private set; }

        public readonly override string ToString()
        {
            var str = $"v {X.FloatToStr()} {Y.FloatToStr()} {Z.FloatToStr()}";

            if (W != 1 | (R != 1 | G != 1 | B != 1)) str += $" {W.FloatToStr()}";

            if (R != 1 | G != 1 | B != 1) str += $" {R.FloatToStr()} {G.FloatToStr()} {B.FloatToStr()}";

            if (A != 1) str += $" {A.FloatToStr()}";

            return str;
        }
    }
}