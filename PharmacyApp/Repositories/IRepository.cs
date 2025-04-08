﻿using Microsoft.EntityFrameworkCore;
using PharmacyApp.Models;
using System.Collections;
using System.Linq.Expressions;

namespace PharmacyApp.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> GetByEmailAsync(string email);

        Task<T> GetByNameAsync(string name);


        Task AddAsync(T entity);

        Task UpdateAsync(T entity);
        
        Task DeleteAsync(int id);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAllAsync(Func<T, bool> predicate);


    }
}
