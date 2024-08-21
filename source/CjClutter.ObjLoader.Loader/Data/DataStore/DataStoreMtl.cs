using System.Collections.Generic;

namespace ObjLoader.Loader.Data.DataStore
{
    public class DataStoreMtl : IDataStoreMtl, IMaterialDataStore
    {
        private readonly List<Material> _materials = new List<Material>();

        public IList<Material> Materials => _materials;

        public void Push(Material material) => _materials.Add(material);
    }
}