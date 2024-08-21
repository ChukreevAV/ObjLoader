using CjClutter.ObjLoader.Loader.Data.VertexData;

using ObjLoader.Loader.Data.VertexData;

namespace ObjLoader.Loader.Data.DataStore
{
    public interface IVertexDataStore
    {
        void AddVertex(Vertex vertex);

        void AddParameterVertex(VertexParameter vertex);
    }
}