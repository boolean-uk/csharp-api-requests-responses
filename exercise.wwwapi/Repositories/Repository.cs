using exercise.wwwapi.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace exercise.wwwapi.Repositories
{
    public class Repository<T> : IRepo<T> where T : class
    {
        private DataContext _db;
        private DbSet<T> _table = null;

        public Repository(DataContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetSingle(Func<T, bool> predicate)
        {
            return _table.FirstOrDefault(predicate);
        }
        
        public T Add(T name)
        {
            _table.Add(name);
            _db.SaveChanges();
            return name;
        }
        public T Remove(Func<T, bool> predicate)
        {
            var entity = _table.FirstOrDefault(predicate);
            if (entity != null)
            {
                _table.Remove(entity);
                _db.SaveChanges();
            }
            return entity;

        }
        public T Update(T name)
        {
            _table.Attach(name);
            _db.Entry(name).State = EntityState.Modified;
            _db.SaveChanges();
            return name;
        }
    }
}
