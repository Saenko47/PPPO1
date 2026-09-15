using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task2.Interfaces
{
    internal interface IRepository<T> where T : class
    {
        List<T> GetAll();
        void Add(T item);

        void Delete(T item);

        void Update(T item);


    }
}
