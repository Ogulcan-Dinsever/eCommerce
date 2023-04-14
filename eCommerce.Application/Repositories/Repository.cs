using eCommerce.Application.Repositories.Interfaces;
using eCommerce.Domain.Common;
using eCommerce.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly eCommerceDbContext _dbContext;

        public Repository(eCommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return await Save();
        }

        public async Task<T> Find(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<int> Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return await Save();
        }

        private async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<bool> Any(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().AsNoTracking().AnyAsync(expression);
        }
        public async Task<int> Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return await Save();
        }
    }
}
