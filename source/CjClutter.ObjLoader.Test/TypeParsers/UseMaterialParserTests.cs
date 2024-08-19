using FluentAssertions;

using NUnit.Framework;

using ObjLoader.Loader.Data.DataStore;
using ObjLoader.Loader.TypeParsers;

namespace ObjLoader.Test.TypeParsers
{
    [TestFixture]
    public class UseMaterialParserTests
    {
        private ElementGroupSpy _elementGroupSpy;
        private MaterialNameParser _parser;

        [SetUp]
        public void SetUp()
        {
            _elementGroupSpy = new ElementGroupSpy();
            _parser = new MaterialNameParser(_elementGroupSpy);
        }

        [Test]
        public void CanParse_returns_true_on_usemtl_line()
        {
            const string groupKeyword = "usemtl";

            bool canParse = _parser.CanParse(groupKeyword);
            canParse.Should().BeTrue();
        }

        [Test]
        public void CanParse_returns_false_on_non_usemtl_line()
        {
            const string invalidKeyword = "vt";

            bool canParse = _parser.CanParse(invalidKeyword);
            canParse.Should().BeFalse();
        }

        [Test]
        public void Parses_usemtl_line_correctly_1()
        {
            const string useMtlLine = "materialName";
            _parser.Parse(useMtlLine);

            _elementGroupSpy.MaterialName.Should().BeEquivalentTo("materialName");
        }

        private class ElementGroupSpy : IMaterialNameDataStore
        {
            public string MaterialName { get; private set; }

            public void PushMaterial(string materialName)
            {
                MaterialName = materialName;
            }
        }
    }
}