using PaterniLab1.Task2.Data;
using PaterniLab1.Task2.Interfaces;
using PaterniLab1.Task2.Models;
using PaterniLab1.Task2.Models.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task2.Realization
{
    internal class LibraryItemRepository: IRepository<BaseLibraryItem>
    {
        private readonly AppDBContextTask2 _context;
        private readonly IRepositoryFactory _repositoryFactory;

        public LibraryItemRepository(AppDBContextTask2 context, IRepositoryFactory repositoryFactory)
        {
            _context = context;
            _repositoryFactory = repositoryFactory;
        }
        public List<BaseLibraryItem> GetAll()
        {
            return _context.LibraryItems.ToList();
        }

        public void Add(BaseLibraryItem item)
        {
            throw new NotImplementedException();
        }
        public void Update(BaseLibraryItem item)
        {
            throw new NotImplementedException();
        }
        public void Delete(BaseLibraryItem item)
        {
            throw new NotImplementedException();
        }
    }
}
