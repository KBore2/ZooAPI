using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ZooAPI.Domain.IRepository
{
    public interface IAsyncRepository<TEntity> where TEntity : class
    {

        public Task<TEntity> AddAsync(TEntity entity);

        public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);

        public Task<TEntity?> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity entity);

        public Task<object?> DeleteAsync(Expression<Func<TEntity, bool>> expression);

        public Task<List<TEntity>> ListAsync();

        public Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> expression);

    }
}
