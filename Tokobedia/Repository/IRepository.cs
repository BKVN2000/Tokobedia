using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tokobedia.Repository
{
    public interface IRepository<TEntity> where TEntity:class
    {
        IEnumerable<TEntity> FindAll();
        TEntity Find(int ID);
        TEntity Insert(TEntity entity);
        void Delete(int ID);
    }
}