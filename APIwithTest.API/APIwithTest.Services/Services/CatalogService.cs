using APIwithTest.Services.Interfaces;
using APIwithTest.Services.Models;
using System.Data;

namespace APIwithTest.Services.Services
{
    public class CatalogService : BaseService<Catalog>, ICatalogService
    {
        private IEnumerable<Catalog> _catalogData = new List<Catalog>
        {
            new Catalog{ Id = 1, Name = "A", TypeCatalogId = 1},
            new Catalog{ Id = 2, Name = "B", TypeCatalogId = 1},
            new Catalog{ Id = 3, Name = "AB", TypeCatalogId = 1},
            new Catalog{ Id = 4, Name = "O", TypeCatalogId = 1},
            new Catalog{ Id = 5, Name = "Celular", TypeCatalogId = 2},
            new Catalog{ Id = 6, Name = "Fijo", TypeCatalogId = 2},
        };

        public CatalogService():base()
        {
            collection = _catalogData;
        }

        public IEnumerable<Catalog> GetByName(Catalog catalog)
        {
            return collection.Where(c => c.Name.ToUpper().Contains(catalog.Name.ToUpper())).AsQueryable();
        }

        public IEnumerable<Catalog> Update(Catalog catalog)
        {
            if (catalog != null)
            {
                Catalog? toUpdate = collection.FirstOrDefault(c => c.Id == catalog.Id);
                if (toUpdate != null)
                {
                    toUpdate.Name = catalog.Name;
                    toUpdate.TypeCatalogId = catalog.TypeCatalogId;
                    return collection.AsQueryable();
                }
                throw new DataException("Item not found.");
            }
            throw new ArgumentNullException("catalog", "The item data must not be mull.");
        }

        public IEnumerable<Catalog> UpdateTypeCatalogId(Catalog catalog)
        {
            if (catalog != null)
            {
                Catalog? toUpdate = collection.FirstOrDefault(c => c.Id == catalog.Id);
                if (toUpdate != null)
                {
                    toUpdate.TypeCatalogId = catalog.TypeCatalogId;
                    return collection.AsQueryable();
                }
                throw new DataException("Item not found.");
            }
            throw new ArgumentNullException("catalog", "The item data must not be mull.");
        }

        public IEnumerable<Catalog> UpdateName(Catalog catalog)
        {
            if (catalog != null)
            {
                Catalog? toUpdate = collection.FirstOrDefault(c => c.Id == catalog.Id);
                if (toUpdate != null)
                {
                    toUpdate.Name = catalog.Name;
                    return collection.AsQueryable();
                }
                throw new DataException("Item not found.");
            }
            throw new ArgumentNullException("catalog", "The item data must not be mull.");
        }
    }
}
