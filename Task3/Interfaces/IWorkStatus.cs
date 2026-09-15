using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task3.Interfaces
{
    internal interface IWorkStatus<T>
    {
         Task SetWorkStatus(int id, bool status);
    }
}
