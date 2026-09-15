using PaterniLab1.Task1.Data;
using PaterniLab1.Task1.Interfaces;
using PaterniLab1.Task1.Model;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace PaterniLab1.Task1.Realization
{
    internal class PersonRepository: IRepository<Person>
    {
        private readonly AppDBContextTask1 _conetext;

        public PersonRepository(AppDBContextTask1 conetext)
        {
            _conetext = conetext;
        }

        public void Save(List<Person> persons) 
        {
            _conetext.AddRange(persons);
            _conetext.SaveChanges();
        }

        public List<Person> GetAll() 
        {
            var persons = _conetext.Persons.ToList();
            return persons;
        }
    }
}
