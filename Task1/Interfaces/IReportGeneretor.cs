using System;
using System.Collections.Generic;
using System.Text;
using PaterniLab1.Task1.Model;

namespace PaterniLab1.Task1.Interfaces
{
    internal interface IReportGeneretor<T> where T : class
    {
        void GenerateReport(List<T> items);
    }
}
