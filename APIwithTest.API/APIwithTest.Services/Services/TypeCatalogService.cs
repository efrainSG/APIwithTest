using APIwithTest.Services.Interfaces;
using APIwithTest.Services.Models;
using System.Data;

namespace APIwithTest.Services.Services
{
    public class TypeCatalogService : BaseService<TypeCatalog>, ITypeCatalogService
    {
        private List<TypeCatalog> _catalogData = new List<TypeCatalog>
        {
            new TypeCatalog{ Id = 1, Name = "Tipo de sangre", Description = "Tipos de sangre existentes"},
            new TypeCatalog{ Id = 2, Name = "Tipo de Teléfono", Description = "Tipos de teléfono de contacto"},
            new TypeCatalog{ Id = 3, Name = "Parentesco", Description = "Tipos de parentesco"}
        };

        public TypeCatalogService():base()
        {
            collection = _catalogData;
        }

        public IEnumerable<TypeCatalog> GetByName(TypeCatalog catalog)
        {
            return collection.Where(c => c.Name.ToUpper().Contains(catalog.Name.ToUpper())).AsQueryable();
        }

        public IEnumerable<TypeCatalog> Update(TypeCatalog catalog)
        {
            if (catalog != null)
            {
                TypeCatalog? toUpdate = collection.FirstOrDefault(c => c.Id == catalog.Id);
                if (toUpdate != null)
                {
                    toUpdate.Name = catalog.Name;
                    toUpdate.Description = catalog.Description;
                    return collection.AsQueryable();
                }
                throw new DataException("catalog not found.");
            }
            throw new ArgumentNullException("catalog", "The catalog type data must not be mull.");
        }

        public IEnumerable<TypeCatalog> UpdateDescription(TypeCatalog catalog)
        {
            if (catalog != null)
            {
                TypeCatalog? toUpdate = collection.FirstOrDefault(c => c.Id == catalog.Id);
                if (toUpdate != null)
                {
                    toUpdate.Description = catalog.Description;
                    return collection.AsQueryable();
                }
                throw new DataException("catalog not found.");
            }
            throw new ArgumentNullException("catalog", "The catalog type data must not be mull.");
        }

        public IEnumerable<TypeCatalog> UpdateName(TypeCatalog catalog)
        {
            if (catalog != null)
            {
                TypeCatalog? toUpdate = collection.FirstOrDefault(c => c.Id == catalog.Id);
                if (toUpdate != null)
                {
                    toUpdate.Name = catalog.Name;
                    return collection.AsQueryable();
                }
                throw new DataException("catalog not found.");
            }
            throw new ArgumentNullException("catalog", "The catalog type data must not be mull.");
        }
    }
}
