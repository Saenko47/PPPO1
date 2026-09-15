using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task2.Interfaces
{
    internal interface IRepositoryFactory
    {
        IRepository<T> CreateRepository<T>() where T : class;
    }
}
