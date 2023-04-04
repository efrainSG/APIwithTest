using APIwithTest.Services.Models;

namespace APIwithTest.Services.Interfaces
{
    public interface IBaseService<T> where T : BaseClass
    {
        IEnumerable<T> GetAll();

        T GetById(T item);

        IEnumerable<T> SaveNew(T item);

        IEnumerable<T> Delete(T item);
    }
}
