using APIwithTest.Services.Interfaces;
using APIwithTest.Services.Models;
using System.Data;

namespace APIwithTest.Services.Services
{
    public class BaseService<T> 
        where T: BaseClass
    {
        public IEnumerable<T> collection { get; set; }

        public IEnumerable<T> GetAll()
        {
            return collection.AsQueryable();
        }

        public T GetById(T item)
        {
            T? result = collection.FirstOrDefault(c => c.Id == item.Id);
            if (result != null)
            {
                return result;
            }
            throw new DataException($"{typeof(T).Name} not found.");
        }

        public IEnumerable<T> SaveNew(T item)
        {
            if (item != null)
            {
                if (!collection.Any(c => c.Id == item.Id))
                {
                    ((List<T>)collection).Add(item);
                    return collection.AsQueryable();
                }
                throw new DataException($"{typeof(T).Name} already exists.");
            }
            throw new ArgumentNullException("item", $"The {typeof(T).Name} data must not be mull.");
        }

        public IEnumerable<T> Delete(T item)
        {
            T? toDelete = collection.FirstOrDefault(t => t.Id == item.Id);
            if (toDelete != null)
            {
                ((List<T>)collection).Remove(toDelete);
                return collection.AsQueryable();
            }
            throw new InvalidDataException("Item not found.");
        }
    }
}
