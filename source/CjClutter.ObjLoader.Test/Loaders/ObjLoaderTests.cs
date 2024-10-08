﻿using System.IO;
using System.Text;
using NUnit.Framework;
using ObjLoader.Loader.Data.DataStore;
using ObjLoader.Loader.Loaders;
using ObjLoader.Loader.TypeParsers;
using System.Linq;
using FluentAssertions;

namespace ObjLoader.Test.Loaders
{
    [TestFixture]
    public class ObjLoaderTests
    {

        private Loader.Loaders.ObjLoader _loader;
        private Loader.Loaders.MtlLoader _loaderMtl;

        private LoadResult _loadResult;
        private LoadResultMtl _loadResultMtl;
        private DataStore _OBJDataStore;
        private DataStoreMtl _MTLDataStore;

        private FaceParser _faceParser;
        private LineParser _lineParser;

        private NormalParser _normalParser;
        private TextureParser _textureParser;
        private VertexParser _vertexParser;
        private MtlLibParser _mtlLibParser;
        private GroupNameParser _groupNameParser;
        private MaterialNameParser _materialnameParser;
        private ObjectNameParser _objectNameParser;

        private MaterialParser _materialParser;

        [SetUp]
        public void SetUp()
        {
            _OBJDataStore = new DataStore();

            _MTLDataStore = new DataStoreMtl();

            _faceParser = new FaceParser(_OBJDataStore);
            _lineParser = new LineParser(_OBJDataStore);
           
            _normalParser = new NormalParser(_OBJDataStore);
            _textureParser = new TextureParser(_OBJDataStore);
            _vertexParser = new VertexParser(_OBJDataStore);

            _groupNameParser = new GroupNameParser(_OBJDataStore);
            _objectNameParser = new ObjectNameParser(_OBJDataStore);
            _materialnameParser = new MaterialNameParser(_OBJDataStore);
            _mtlLibParser = new MtlLibParser(_OBJDataStore);

            _materialParser = new MaterialParser(_MTLDataStore);

            _loader = new Loader.Loaders.ObjLoader(
                _OBJDataStore,
                _faceParser,
                _lineParser,
                _normalParser,
                _textureParser,
                _vertexParser,
                _mtlLibParser,
                _groupNameParser,
                _materialnameParser,
                _objectNameParser
                );

            _loaderMtl = new MtlLoader(_MTLDataStore, _materialParser);
        }

        [Test]
        public void Loads_object_and_material_correctly()
        {
            Load();

            _loadResult.Vertices.Should().HaveCount(8);
            _loadResult.Textures.Should().HaveCount(14);
            _loadResult.Normals.Should().HaveCount(8);
            _loadResultMtl.Materials.Should().HaveCount(1);

            _loadResult.Mtllibs.Should().HaveCount(1);
            var mtllib = _loadResult.Mtllibs.First();
            mtllib.Should().BeEquivalentTo("cube.mtl");

            _loadResult.Groups.Should().HaveCount(1);

            var group = _loadResult.Groups.First();
            group.Faces.Should().HaveCount(12);
            group.MaterialName.Should().BeEquivalentTo("cube_material");
        }

        [Test]
        public void Loads_object_correctly_when_material_is_not_found()
        {
            Load();

            _loadResult.Vertices.Should().HaveCount(8);
            _loadResult.Textures.Should().HaveCount(14);
            _loadResult.Normals.Should().HaveCount(8);

            _loadResult.Groups.Should().HaveCount(1);

            var group = _loadResult.Groups.First();
            group.Faces.Should().HaveCount(12);
            group.MaterialName.Should().BeEquivalentTo("cube_material");
        }

        private void Load()
        {
            var objectStream = new StreamReader(CreateMemoryStreamFromString(ObjectFileString));

            _loadResult = _loader.Load(objectStream);

            var mtlStream = new StreamReader(CreateMemoryStreamFromString(MaterialLibraryString));

            _loadResultMtl = _loaderMtl.Load(mtlStream);
        }

        private Stream CreateMemoryStreamFromString(string str)
        {
            var data = Encoding.ASCII.GetBytes(str);
            return new MemoryStream(data);
        }

        private const string ObjectFileString = 
"#Comment\r\n" + 
"mtllib\tcube.mtl\r\n" + 
@"v 1.000000 -1.000000 -1.000000
v  1.000000 -1.000000 1.000000
v -1.000000 -1.000000 1.000000   
v -1.000000 -1.000000 -1.000000
v 1.000000 1.000000 -1.000000
v 0.999999 1.000000 1.000001
v -1.000000 1.000000 1.000000
v -1.000000 1.000000 -1.000000
vt 0.748573 0.750412
vt 0.749279 0.501284
vt 0.999110 0.501077
vt 0.999455 0.750380
vt 0.250471 0.500702
vt 0.249682 0.749677
vt 0.001085 0.750380
vt 0.001517 0.499994
vt 0.499422 0.500239
vt 0.500149 0.750166
vt 0.748355 0.998230
vt 0.500193 0.998728
vt 0.498993 0.250415
vt 0.748953 0.250920


vn 0.000000 0.000000 -1.000000
vn -1.000000 -0.000000 -0.000000
vn -0.000000 -0.000000 1.000000
vn -0.000001 0.000000 1.000000
vn 1.000000 -0.000000 0.000000
vn 1.000000 0.000000 0.000001
vn 0.000000 1.000000 -0.000000
vn -0.000000 -1.000000 0.000000
usemtl cube_material
s off
f 5/1/1 1/2/1 4/3/1
f 5/1/1 4/3/1 8/4/1
f 3/5/2 7/6/2 8/7/2
f 3/5/2 8/7/2 4/8/2
f 2/9/3 6/10/3 3/5/3
f 6/10/4 7/6/4 3/5/4
f 1/2/5 5/1/5 2/9/5
f 5/1/6 6/10/6 2/9/6
f 5/1/7 8/11/7 6/10/7
f 8/11/7 7/12/7 6/10/7
f 1/2/8 2/9/8 3/13/8
f 1/2/8 3/13/8 4/14/8";

        private const string MaterialLibraryString =
@"newmtl cube_material
Ns 32
Tr 0.5
illum 2
Ka 1.0000 2.0000 3.0000
Kd 0.5255 0.4314 0.0314
Ks 0.3500 0.3600 0.3700
map_Ka lenna1.tga
map_Kd lenna2.tga
map_Ks lenna3.tga
map_Ns lenna_spec.tga
map_d lenna_alpha.tga
map_bump lenna_bump.tga
disp lenna_disp.tga
decal lenna_stencil.tga";
    }
}