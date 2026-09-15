using PaterniLab1.Task2.Data;
using PaterniLab1.Task2.Interfaces;
using PaterniLab1.Task2.Models.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task2.Realization
{
    internal class BookRepository:IRepository<Book>
    {
        private readonly AppDBContextTask2 _context;

        public BookRepository(AppDBContextTask2 context)
        {
            _context = context;
        }
        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public void Add(Book item)
        {
            throw new NotImplementedException();
        }
        public void Update(Book item)
        {
            throw new NotImplementedException();
        }
        public void Delete(Book item)
        {
            throw new NotImplementedException();
        }
    }
}
