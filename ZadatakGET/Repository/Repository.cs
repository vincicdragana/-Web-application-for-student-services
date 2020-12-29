using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ZadatakGET.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext DB;
        protected readonly DbSet<TEntity> set;
        public Repository(DbContext db)
        {
            DB = db;
            set = db.Set<TEntity>();
        }

        public virtual void Create(TEntity entity)
        {
            set.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (DB.Entry(entity).State == EntityState.Deleted) set.Attach(entity);
            set.Remove(entity);
        }

        public virtual void Edit(TEntity entity)
        {
            set.Attach(entity);
            DB.Entry(entity).State = EntityState.Modified;
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return set.Where(predicate);
        }

        public virtual TEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return set.ToList();
        }

    }
}