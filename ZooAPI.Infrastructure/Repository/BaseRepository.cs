using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooAPI.Domain.IRepository;
using ZooAPI.Infrastructure.Data;
using MediatR;

namespace ZooAPI.Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : class
    {
        private readonly ZooDbContext dbContext;
        private readonly DbSet<TEntity> dbSet;

        public BaseRepository(ZooDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public async Task<object?> DeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            var response = await dbSet.Where(expression).FirstAsync();
            if (response == null)
                return null;

            dbContext.Remove(response);
            dbContext.SaveChanges();
            return response;
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await dbSet.Where(expression).FirstAsync();
        }

        public async Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> expression)
        {
           return await dbSet.Where(expression).ToListAsync();
        }

        public async Task<List<TEntity>> ListAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<TEntity?> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity entity)
        {
            var response = await dbSet.Where(expression).FirstAsync();
            if (response == null)
                return null;

            dbSet.Update(entity);
            dbContext.SaveChanges();
            return await Task.FromResult(entity);
        }
    }
}
