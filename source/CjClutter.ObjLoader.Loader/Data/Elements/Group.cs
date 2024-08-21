using System.Collections.Generic;
using System.Text;

using ObjLoader.Loader.Data.DataStore;

namespace ObjLoader.Loader.Data.Elements
{
    public class Group : IFaceGroup, ILineGroup
    {
        private readonly List<Face> _faces = new List<Face>();
        
        private readonly List<Line> _lines = new List<Line>();
        
        public Group(string groupName, string materialName, string objectName)
        {
            GroupName = groupName;
            MaterialName = materialName;
            ObjectName = objectName;
        }

        public string GroupName { get; private set; }

        public int? Smoothing { get; private set; }

        public string MaterialName { get; private set; }

        public string ObjectName { get; private set; }

        public IList<Face> Faces => _faces;

        public IList<Line> Lines => _lines;

        public void AddFace(Face face) => _faces.Add(face);

        public void AddLine(Line line) => _lines.Add(line);

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (GroupName != "default") //TODO remove magic
            {
                sb.AppendLine($"g {GroupName}");
            }

            foreach (var face in _faces)
            {
                sb.AppendLine(face.ToString());
            }

            return sb.ToString();
        }
    }
}