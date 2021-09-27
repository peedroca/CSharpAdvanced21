using System.Collections.Generic;

namespace apiwithpomelo.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Delete(T entity);
        T Get(object pk);
    }
}