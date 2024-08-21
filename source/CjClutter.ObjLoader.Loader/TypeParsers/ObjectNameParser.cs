using ObjLoader.Loader.Data.DataStore;
using ObjLoader.Loader.TypeParsers.Interfaces;

namespace ObjLoader.Loader.TypeParsers
{
    public class ObjectNameParser : TypeParserBase, IObjectNameParser
    {
        private readonly IObjectNameDataStore _objectNameDataStore;

        public ObjectNameParser(IObjectNameDataStore objectNameDataStore)
        {
            _objectNameDataStore = objectNameDataStore;
        }

        protected override string Keyword => "o";

        public override void Parse(string line)
        {
            _objectNameDataStore.PushObject(line);
        }
    }
}
