using APIwithTest.Services.Interfaces;
using APIwithTest.Services.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIwithTest.Services.Services
{
    public class TypeCatalogService : ITypeCatalogService
    {
        private List<TypeCatalog> _catalogData = new List<TypeCatalog>
        {
            new TypeCatalog{ Id = 1, Name = "Tipo de sangre", Description = "Tipos de sangre existentes"}
        };

        public IEnumerable<TypeCatalog> GetAll()
        {
            return _catalogData.AsQueryable();
        }

        public TypeCatalog GetById(TypeCatalog catalog)
        {
            TypeCatalog? result = _catalogData.FirstOrDefault(c => c.Id == catalog.Id);
            if (result != null)
            {
                return result;
            }
            throw new DataException("Catalog not found.");
        }

        public IEnumerable<TypeCatalog> GetByName(TypeCatalog catalog)
        {
            return _catalogData.Where(c => c.Name.ToUpper().Contains(catalog.Name.ToUpper())).AsQueryable();
        }

        public IEnumerable<TypeCatalog> SaveNew(TypeCatalog catalog)
        {
            if (catalog != null)
            {
                if (!_catalogData.Any(c => c.Id == catalog.Id))
                {
                    _catalogData.Add(catalog);
                    return _catalogData.AsQueryable();
                }
                throw new DataException("Catalog already exists.");
            }
            throw new ArgumentNullException("catalog", "The catalog type data must not be mull.");
        }

        public IEnumerable<TypeCatalog> Update(TypeCatalog catalog)
        {
            if (catalog != null)
            {
                TypeCatalog? toUpdate = _catalogData.FirstOrDefault(c => c.Id == catalog.Id);
                if (toUpdate != null)
                {
                    toUpdate.Name = catalog.Name;
                    toUpdate.Description = catalog.Description;
                    return _catalogData.AsQueryable();
                }
                throw new DataException("catalog not found.");
            }
            throw new ArgumentNullException("catalog", "The catalog type data must not be mull.");
        }

        public IEnumerable<TypeCatalog> UpdateDescription(TypeCatalog catalog)
        {
            if (catalog != null)
            {
                TypeCatalog? toUpdate = _catalogData.FirstOrDefault(c => c.Id == catalog.Id);
                if (toUpdate != null)
                {
                    toUpdate.Description = catalog.Description;
                    return _catalogData.AsQueryable();
                }
                throw new DataException("catalog not found.");
            }
            throw new ArgumentNullException("catalog", "The catalog type data must not be mull.");
        }

        public IEnumerable<TypeCatalog> UpdateName(TypeCatalog catalog)
        {
            if (catalog != null)
            {
                TypeCatalog? toUpdate = _catalogData.FirstOrDefault(c => c.Id == catalog.Id);
                if (toUpdate != null)
                {
                    toUpdate.Name = catalog.Name;
                    return _catalogData.AsQueryable();
                }
                throw new DataException("catalog not found.");
            }
            throw new ArgumentNullException("catalog", "The catalog type data must not be mull.");
        }

        public IEnumerable<TypeCatalog> Delete(TypeCatalog catalog)
        {
            TypeCatalog? toDelete = _catalogData.FirstOrDefault(t => t.Id == catalog.Id);
            if (toDelete != null)
            {
                _catalogData.Remove(toDelete);
                return _catalogData.AsQueryable();
            }
            throw new InvalidDataException("Catalog not found.");
        }
    }
}
