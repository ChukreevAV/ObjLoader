using System.Collections.Generic;

namespace ObjLoader.Loader.Data.DataStore
{
    public interface IDataStoreMtl
    {
        IList<Material> Materials { get; }
    }
}