using Microsoft.Extensions.DependencyModel;
using PaterniLab1.Task2.Data;
using PaterniLab1.Task2.Interfaces;
using PaterniLab1.Task2.Models.Books;
using PaterniLab1.Task2.Models.Newspapers;
using System;
using System.Collections.Generic;
using System.Text;
using static PaterniLab1.Task2.Tools.Enums;

namespace PaterniLab1.Task2.Realization
{
    internal class RepositoryFactory: IRepositoryFactory
    {
        private readonly AppDBContextTask2 _context;

        public RepositoryFactory(AppDBContextTask2 context)
        {
            _context = context;
        }

        public IRepository<T> CreateRepository<T>() where T : class 
        {
            if (typeof(T) == typeof(Book)) return (IRepository<T>)new BookRepository(_context);

            if (typeof(T) == typeof(Newspaper)) return (IRepository<T>)new NewspaperRepository(_context);

            if (typeof(T) == typeof(Newspaper)) return (IRepository<T>)new AlmanacRepository(_context);

            throw new NotSupportedException($"Repo issues");
        }
    }
}
