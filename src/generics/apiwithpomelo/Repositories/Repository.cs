using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using apiwithpomelo.Entities;

namespace apiwithpomelo.Repositories 
{
    internal abstract class Repository<T> where T : class
    {
        private readonly mysql_17753_devmonkContext _context;

        public Repository(DbContext context)
        {
            _context = (mysql_17753_devmonkContext)context;
        }

        public virtual void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>()
                .AsNoTracking()
                .ToList();
        }

        public virtual void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public virtual T Get(object pk)
        {
            return _context.Find<T>(pk);
        }
    }
}