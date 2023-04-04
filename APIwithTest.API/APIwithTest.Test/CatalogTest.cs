using APIwithTest.Services.Interfaces;
using APIwithTest.Services.Models;
using APIwithTest.Services.Services;

namespace APIwithTest.Test
{
    public class CatalogTest
    {
        private ICatalogService service;

        [SetUp]
        public void Setup()
        {
            service = new CatalogService();
        }

        [Test]
        public void GetAllTest()
        {
            var result = service.GetAll();
            Assert.True(result != null);
            Assert.True(result?.Count() != 0);
            Assert.True(result?.Count() == 6);
        }

        [Test]
        public void GetByIdTest()
        {
            var result = service.GetById(new Catalog { Id = 5});
            Assert.True(result != null);
            Assert.True(result?.Name == "Celular");
        }

        [Test]
        public void GetByNameTest()
        {
            var result = service.GetByName(new Catalog { Name = "A" });
            Assert.True(result != null);
            Assert.True(result?.Count() != 0);
            Assert.True(result?.Count() == 3);
        }

        [Test]
        public void SaveTest()
        {
            var result = service.SaveNew(new Catalog { Id = 7, Name = "Padre", TypeCatalogId = 3 });
            Assert.True(result != null);
            Assert.True(result?.Count() != 0);
            Assert.True(result?.Count() == 7);
        }

        [Test]
        public void UpdateTest()
        {
            Catalog toUpdate = new Catalog { Id = 6, Name = "Casa", TypeCatalogId = 3 };
            Catalog original = service.GetById(toUpdate);

            var result = service.Update(toUpdate);

            Assert.True(result != null);
            Assert.True(result?.Count() != 0);
            Assert.True(result?.Count() == 6);
            Assert.True(result?.First(r => r.Id == toUpdate.Id).Name.ToUpper() == toUpdate.Name.ToUpper());
        }
    }
}
