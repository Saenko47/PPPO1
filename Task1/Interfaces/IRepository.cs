using PaterniLab1.Task1.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task1.Interfaces
{
    internal interface IRepository<T> where T : class
    {
        void Save(List<T> items);
        List<T> GetAll();
    }
}
