using backend.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public async Task<IEnumerable<TEntity>> Get(int count, int skip) => await _db.Set<TEntity>().Skip(skip).Take(count).ToListAsync();

        public async Task<IEnumerable<TEntity>> Get() => await _db.Set<TEntity>().ToListAsync();

        public async Task<TEntity> Get(int id) => await _db.Set<TEntity>().FindAsync(id);

        public async Task<TEntity> Update(TEntity o, int id)
        {
            TEntity entity = await _db.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _db.Entry(entity).CurrentValues.SetValues(o);
                await _db.SaveChangesAsync();
            }
            return o;
        }

        public async Task<TEntity> Insert(TEntity o)
        {
            _db.Set<TEntity>().Add(o);
            await _db.SaveChangesAsync();
            return o;
        }

        public async Task<TEntity> Delete(int id)
        {
            TEntity entity = await _db.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _db.Set<TEntity>().Remove(entity);
                await _db.SaveChangesAsync();
            }
            return entity;
        }

        public Repository(Context db) => _db = db;
        private readonly Context _db;
    }
}
