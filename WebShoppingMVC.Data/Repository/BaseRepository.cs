using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebShoppingMVC.Data.Context;
using WebShoppingMVC.Data.Repository.Interface;

namespace WebShoppingMVC.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> Create(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public void Delete(int id)
        {
            var query = _dbContext.Set<T>().Find(id);
            if (query != null)
            {
                _dbContext.Set<T>().Remove(query);
                SaveChanges();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            if (expression == null)
            {
                return await _dbContext.Set<T>().ToListAsync();
            }
            return await _dbContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task Update(T entity)
        {
            await _dbContext.SaveChangesAsync();
        }

        //public Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression = null)
        //{
        //    throw new NotImplementedException();
        //}

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
