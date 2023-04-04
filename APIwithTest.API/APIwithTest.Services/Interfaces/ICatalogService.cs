using APIwithTest.Services.Models;

namespace APIwithTest.Services.Interfaces
{
    public interface ICatalogService : IBaseService<Catalog>
    {
        IEnumerable<Catalog> GetByName(Catalog item);

        IEnumerable<Catalog> Update(Catalog item);

        IEnumerable<Catalog> UpdateName(Catalog item);

        IEnumerable<Catalog> UpdateTypeCatalogId(Catalog item);
    }
}
