using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tokobedia.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected TokobediaEntities1 Context;


        public BaseRepository(TokobediaEntities1 Context)
        {
            this.Context = Context;
        }

        public IEnumerable<TEntity> FindAll()
        {
            return Context.Set<TEntity>();
        }

        public TEntity Find(int ID) => Context.Set<TEntity>().Find(ID);

        public TEntity Insert(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
            return entity;
        }
        public void Delete(int ID)
        {
            TEntity t = Context.Set<TEntity>().Find(ID);
            Context.Set<TEntity>().Remove(t);
            Context.SaveChanges();
        }
    }
}