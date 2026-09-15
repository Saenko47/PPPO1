using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using PaterniLab1.Task3.Data;
using PaterniLab1.Task3.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PaterniLab1.Task3.BaseClass
{
    internal class BaseRepositoryTask3<T> where T : class
    {
        public readonly DbSet<T> _context;
        protected readonly AppDBContextTask3 _dbContext;


        public BaseRepositoryTask3(AppDBContextTask3 context)
        {
            _context = context.Set<T>();
            _dbContext = context;
        }



        public virtual async Task<T?> GetById(int id)
        {
            return await _context.FindAsync(id);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _context.ToListAsync();
        }

        public virtual void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public virtual async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();

        }
    }
}
