using Microsoft.EntityFrameworkCore;
using PaterniLab1.Task2.Data;
using PaterniLab1.Task2.Interfaces;
using PaterniLab1.Task2.Models.Books;
using PaterniLab1.Task2.Models.Newspapers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task2.Realization
{
    internal class NewspaperRepository: IRepository<Newspaper>
    {
        private readonly AppDBContextTask2 _context;

        public NewspaperRepository(AppDBContextTask2 context)
        {
            _context = context;
        }

        public List<Newspaper> GetAll()
        {
            return _context.Newspapers.ToList();
        }

        public void Add(Newspaper item)
        {
            throw new NotImplementedException();
        }
        public void Update(Newspaper item)
        {
            throw new NotImplementedException();
        }
        public void Delete(Newspaper item)
        {
            throw new NotImplementedException();
        }
    }
}
