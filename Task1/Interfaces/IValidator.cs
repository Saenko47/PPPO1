using PaterniLab1.Task1.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task1.Interfaces
{
    internal interface IValidator<T> where T : class
    {
        bool Validate(T item);   
    }
}
