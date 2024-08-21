using System.IO;

using NUnit.Framework;

using ObjLoader.Loader.Loaders;

namespace CjClutter.ObjLoader.Test.Loaders
{
    [TestFixture]
    public class Tests1
    {
        [Test]
        public void Test1()
        {
            var path1 = @"Data\NewSimple1.obj";
            var loader = ObjLoaderFactory.Create();
            using var stream = new StreamReader(path1);
            var result = loader.Load(stream);
            result.Save("Data\\NewSimple2.obj");
        }
    }
}