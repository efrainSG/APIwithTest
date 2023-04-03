using APIwithTest.Services.Interfaces;
using APIwithTest.Services.Services;

namespace APIwithTest.Test
{
    public class TypeCatalogTest
    {
        private ITypeCatalogService service;

        [SetUp]
        public void Setup()
        {
            service = new TypeCatalogService();
        }

        [Test]
        public void GetAllTest()
        {
            var result = service.GetAll();
            Assert.True(result != null);
            Assert.True(result?.Count() != 0);
        }
    }
}
