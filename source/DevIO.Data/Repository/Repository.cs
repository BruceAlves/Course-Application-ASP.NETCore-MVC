using DevIO.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    //só pode ser herdada
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public Task Adding(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Deleteing(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

     
        public Task<List<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
