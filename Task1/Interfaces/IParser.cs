using PaterniLab1.Task1.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static PaterniLab1.Task1.Tools.Enums;

namespace PaterniLab1.Task1.Interfaces
{
    internal interface IParser<T> where T : class
    {
        List<T> Parse(string input, TypeOfData typeOfData);
    }
}
