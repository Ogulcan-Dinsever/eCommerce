﻿using eCommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task Create(T entity);
        Task CreateAll(List<T> entities);
        Task<T> Find(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAll();
        Task<List<T>> GetAll(Expression<Func<T, bool>> expression);
        Task Update(T entity);
        Task<bool> Any(Expression<Func<T, bool>> expression);
        Task<int> Delete(Expression<Func<T, bool>> entity);
    }
}
