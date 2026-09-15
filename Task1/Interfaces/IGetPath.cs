using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task1.Interfaces
{
    internal interface IGetPath
    {
        string GetPath(string? initialDirectory = null);
    }
}
