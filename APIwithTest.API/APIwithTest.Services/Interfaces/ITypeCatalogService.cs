using APIwithTest.Services.Models;

namespace APIwithTest.Services.Interfaces
{
    public interface ITypeCatalogService: IBaseService<TypeCatalog>
    {
        IEnumerable<TypeCatalog> GetByName(TypeCatalog catalog);

        IEnumerable<TypeCatalog> Update(TypeCatalog catalog);

        IEnumerable<TypeCatalog> UpdateName(TypeCatalog catalog);

        IEnumerable<TypeCatalog> UpdateDescription(TypeCatalog catalog);
    }
}
