using ObjLoader.Loader.Data;
using ObjLoader.Loader.Data.DataStore;
using ObjLoader.Loader.TypeParsers.Interfaces;

namespace ObjLoader.Loader.TypeParsers
{
    public class MaterialParser : IMaterialParser
    {
        private readonly IMaterialDataStore _materialDataStore;

        public MaterialParser(IMaterialDataStore materialDataStore)
        {
            _materialDataStore = materialDataStore;
        }

        public void AddMaterial(Material material)
        {
            _materialDataStore.Push(material);
        }
    }
}
