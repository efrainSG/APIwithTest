using APIwithTest.Services.Interfaces;
using APIwithTest.Services.Models;
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
            Assert.True(result?.Count() == 1);
        }

        [Test]
        public void GetByIdTest()
        {
            var result = service.GetById(new TypeCatalog { Id = 1});
            Assert.True(result != null);
            Assert.True(result?.Name == "Tipo de sangre");
        }

        [Test]
        public void GetByNameTest()
        {
            var result = service.GetByName(new TypeCatalog { Name = "Tipo" });
            Assert.True(result != null);
            Assert.True(result?.Count() != 0);
            Assert.True(result?.Count() == 1);
        }

        [Test]
        public void SaveTest()
        {
            var result = service.SaveNew(new TypeCatalog { Id = 2, Name = "Tipo de teléfono", Description = "Tipos de teléfono que se pueden registrar" });
            Assert.True(result != null);
            Assert.True(result?.Count() != 0);
            Assert.True(result?.Count() == 2);
        }

        [Test]
        public void UpdateTest()
        {
            TypeCatalog toUpdate = new TypeCatalog { Id = 1, Name = "Tipo de teléfono", Description = "Tipos de teléfono que se pueden registrar" };
            TypeCatalog original = service.GetById(toUpdate);

            var result = service.Update(toUpdate);

            Assert.True(result != null);
            Assert.True(result?.Count() != 0);
            Assert.True(result?.Count() == 1);
            Assert.True(result?.First(r => r.Id == toUpdate.Id).Name.ToUpper() == toUpdate.Name.ToUpper());
        }
    }
}
