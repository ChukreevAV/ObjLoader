using NUnit.Framework;
using ObjLoader.Loader.Loaders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjLoader.Test.Loaders
{
    [TestFixture]
    public class ObjLoaderExtraTests
    {
        private IObjLoader _loader;


        [SetUp]
        public void SetUp()
        {
            ObjLoader.Loader.Loaders.ObjLoaderFactory loaderFactory = new ObjLoader.Loader.Loaders.ObjLoaderFactory();
            _loader = loaderFactory.Create();
        }

        [Test]
        public void TestEmpatyFile() 
        {
            var _loadResult = _loader.Load(CreateStreamReaderFromString(""));

            Assert.AreNotEqual(null, _loadResult);
            Assert.IsTrue(_loadResult.Normals.Count == 0);
            Assert.IsTrue(_loadResult.Mtllibs.Count == 0);
            Assert.IsTrue(_loadResult.Groups.Count == 0);
            Assert.IsTrue(_loadResult.Textures.Count == 0);
            Assert.IsTrue(_loadResult.Vertices.Count == 0);
        }

        private string file1 =
@"#coment
f 1 2 3
o Obj1
g group1
usemtl material1
f 4 5 6
o Obj2
f 7 8 9
g group2
f 10 11 12
usemtl material2
f 13 14 15
";
        [Test]
        public void TestGroups()
        {
            var _loadResult = _loader.Load(CreateStreamReaderFromString(file1));

           
            Assert.IsTrue(_loadResult.Groups.Count == 5);
            Assert.IsTrue(_loadResult.Groups[0].GroupName == "default");
            Assert.IsTrue(_loadResult.Groups[0].ObjectName == "default");
            Assert.IsTrue(_loadResult.Groups[0].MaterialName == "default");

            Assert.IsTrue(_loadResult.Groups[1].GroupName == "group1");
            Assert.IsTrue(_loadResult.Groups[1].ObjectName == "Obj1");
            Assert.IsTrue(_loadResult.Groups[1].MaterialName == "material1");

            Assert.IsTrue(_loadResult.Groups[2].GroupName == "group1");
            Assert.IsTrue(_loadResult.Groups[2].ObjectName == "Obj2");
            Assert.IsTrue(_loadResult.Groups[2].MaterialName == "material1");

            Assert.IsTrue(_loadResult.Groups[3].GroupName == "group2");
            Assert.IsTrue(_loadResult.Groups[3].ObjectName == "Obj2");
            Assert.IsTrue(_loadResult.Groups[3].MaterialName == "material1");

            Assert.IsTrue(_loadResult.Groups[4].GroupName == "group2");
            Assert.IsTrue(_loadResult.Groups[4].ObjectName == "Obj2");
            Assert.IsTrue(_loadResult.Groups[4].MaterialName == "material2");
        }


        private string file2 =
  @"#coment
g group
usemtl material1
f 1 2 3
usemtl material2
f 4 5 6
usemtl material3
f 7 8 9
";
        [Test]
        public void TestGroupsMaterial()
        {
            var _loadResult = _loader.Load(CreateStreamReaderFromString(file2));

            Assert.IsTrue(_loadResult.Groups.Count == 3);
            Assert.IsTrue(_loadResult.Groups[0].GroupName == "group");
            Assert.IsTrue(_loadResult.Groups[0].ObjectName == "default");
            Assert.IsTrue(_loadResult.Groups[0].MaterialName == "material1");

            Assert.IsTrue(_loadResult.Groups[1].GroupName == "group");
            Assert.IsTrue(_loadResult.Groups[1].ObjectName == "default");
            Assert.IsTrue(_loadResult.Groups[1].MaterialName == "material2");

            Assert.IsTrue(_loadResult.Groups[2].GroupName == "group");
            Assert.IsTrue(_loadResult.Groups[2].ObjectName == "default");
            Assert.IsTrue(_loadResult.Groups[2].MaterialName == "material3");
        }


        private string file3 =
  @"#coment
v  0  3  6
v  9 12 15 18
v 21 24 27 30 33 36
v 39 42 45 48 51 54 57
";



        [Test]
        public void TestVerticeRGBA()
        {
            var _loadResult = _loader.Load(CreateStreamReaderFromString(file3));

            Assert.IsTrue(_loadResult.Vertices.Count == 4);

            Assert.IsTrue(_loadResult.Vertices[0].X == 0f);
            Assert.IsTrue(_loadResult.Vertices[0].Y == 3f);
            Assert.IsTrue(_loadResult.Vertices[0].Z == 6f);
            Assert.IsTrue(_loadResult.Vertices[0].W == 1f);
            Assert.IsTrue(_loadResult.Vertices[0].R == 1f);
            Assert.IsTrue(_loadResult.Vertices[0].G == 1f);
            Assert.IsTrue(_loadResult.Vertices[0].B == 1f);
            Assert.IsTrue(_loadResult.Vertices[0].A == 1f);

            Assert.IsTrue(_loadResult.Vertices[1].X == 9f);
            Assert.IsTrue(_loadResult.Vertices[1].Y == 12f);
            Assert.IsTrue(_loadResult.Vertices[1].Z == 15f);
            Assert.IsTrue(_loadResult.Vertices[1].W == 18f);
            Assert.IsTrue(_loadResult.Vertices[1].R == 1f);
            Assert.IsTrue(_loadResult.Vertices[1].G == 1f);
            Assert.IsTrue(_loadResult.Vertices[1].B == 1f);
            Assert.IsTrue(_loadResult.Vertices[1].A == 1f);

            Assert.IsTrue(_loadResult.Vertices[2].X == 21f);
            Assert.IsTrue(_loadResult.Vertices[2].Y == 24f);
            Assert.IsTrue(_loadResult.Vertices[2].Z == 27f);
            Assert.IsTrue(_loadResult.Vertices[2].W == 1f);
            Assert.IsTrue(_loadResult.Vertices[2].R == 30f);
            Assert.IsTrue(_loadResult.Vertices[2].G == 33f);
            Assert.IsTrue(_loadResult.Vertices[2].B == 36f);
            Assert.IsTrue(_loadResult.Vertices[2].A == 1f);

            Assert.IsTrue(_loadResult.Vertices[3].X == 39f);
            Assert.IsTrue(_loadResult.Vertices[3].Y == 42f);
            Assert.IsTrue(_loadResult.Vertices[3].Z == 45f);
            Assert.IsTrue(_loadResult.Vertices[3].W == 1f);
            Assert.IsTrue(_loadResult.Vertices[3].R == 48f);
            Assert.IsTrue(_loadResult.Vertices[3].G == 51f);
            Assert.IsTrue(_loadResult.Vertices[3].B == 54f);
            Assert.IsTrue(_loadResult.Vertices[3].A == 57f);
        }


        private string file4 =
@"#coment
g group1
l 4 5 6
l 7 8 9 10 11
g group2
l 10 11 12 13
";
        [Test]
        public void TestLines()
        {
            var _loadResult = _loader.Load(CreateStreamReaderFromString(file4));


            Assert.IsTrue(_loadResult.Groups.Count == 2);
            Assert.IsTrue(_loadResult.Groups[0].Lines[0][0] == 4);
            Assert.IsTrue(_loadResult.Groups[0].Lines[0][1] == 5);
            Assert.IsTrue(_loadResult.Groups[0].Lines[0][2] == 6);
            
            Assert.IsTrue(_loadResult.Groups[0].Lines[1][0] == 7);
            Assert.IsTrue(_loadResult.Groups[0].Lines[1][1] == 8);
            Assert.IsTrue(_loadResult.Groups[0].Lines[1][2] == 9);
            Assert.IsTrue(_loadResult.Groups[0].Lines[1][3] == 10);
            Assert.IsTrue(_loadResult.Groups[0].Lines[1][4] == 11);

            Assert.IsTrue(_loadResult.Groups[1].Lines[0][0] == 10);
            Assert.IsTrue(_loadResult.Groups[1].Lines[0][1] == 11);
            Assert.IsTrue(_loadResult.Groups[1].Lines[0][2] == 12);
            Assert.IsTrue(_loadResult.Groups[1].Lines[0][3] == 13);

        }


        private string file5 =
@"o obj1
g group1
usemtl material1
";
        [Test]
        public void TestGroupsNoFaces()
        {
            var _loadResult = _loader.Load(CreateStreamReaderFromString(file5));

            Assert.IsTrue(_loadResult.Groups.Count == 0);
        }

        private string file6 =
@"o obj1
g group1
usemtl material1
f 1 2 3
";
        [Test]
        public void TestGroupsOneFace()
        {
            var _loadResult = _loader.Load(CreateStreamReaderFromString(file6));

            Assert.IsTrue(_loadResult.Groups.Count == 1);
            Assert.IsTrue(_loadResult.Groups[0].ObjectName == "obj1");
            Assert.IsTrue(_loadResult.Groups[0].GroupName == "group1");
            Assert.IsTrue(_loadResult.Groups[0].MaterialName == "material1");
        }


        private string file7 =
@"o 
g 
usemtl 
f 1 2 3
";
        [Test]
        public void TestGroupsNoName()
        {
            var _loadResult = _loader.Load(CreateStreamReaderFromString(file7));

            Assert.IsTrue(_loadResult.Groups.Count == 1);
            Assert.IsTrue(_loadResult.Groups[0].ObjectName == "");
            Assert.IsTrue(_loadResult.Groups[0].GroupName == "");
            Assert.IsTrue(_loadResult.Groups[0].MaterialName == "");
        }



        private StreamReader CreateStreamReaderFromString(string str)
        {
            var data = Encoding.ASCII.GetBytes(str);
            return new StreamReader(new MemoryStream(data));
        }

    }
}
