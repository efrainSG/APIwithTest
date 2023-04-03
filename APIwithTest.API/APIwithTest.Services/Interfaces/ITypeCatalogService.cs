using APIwithTest.Services.Models;

namespace APIwithTest.Services.Interfaces
{
    public interface ITypeCatalogService
    {
        IEnumerable<TypeCatalog> GetAll();

        IEnumerable<TypeCatalog> GetByName(TypeCatalog catalog);

        TypeCatalog GetById(TypeCatalog catalog);

        IEnumerable<TypeCatalog> SaveNew(TypeCatalog catalog);

        IEnumerable<TypeCatalog> Update(TypeCatalog catalog);

        IEnumerable<TypeCatalog> UpdateName(TypeCatalog catalog);

        IEnumerable<TypeCatalog> UpdateDescription(TypeCatalog catalog);

        IEnumerable<TypeCatalog> Delete(TypeCatalog catalog);
    }
}
