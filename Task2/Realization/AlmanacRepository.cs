using PaterniLab1.Task2.Data;
using PaterniLab1.Task2.Interfaces;
using PaterniLab1.Task2.Models.Amanacs;
using PaterniLab1.Task2.Models.Newspapers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task2.Realization
{
    internal class AlmanacRepository: IRepository<Almanac>
    {
        private readonly AppDBContextTask2 _context;

        public AlmanacRepository(AppDBContextTask2 context)
        {
            _context = context;
        }

        public List<Almanac> GetAll()
        {
            return _context.Almanacs.ToList();
        }

        public void Add(Almanac item)
        {
            throw new NotImplementedException();
        }
        public void Update(Almanac item)
        {
            throw new NotImplementedException();
        }
        public void Delete(Almanac item)
        {
            throw new NotImplementedException();
        }
    }
}
