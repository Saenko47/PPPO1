using PaterniLab1.Task1.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace PaterniLab1.Task1.Realization
{
    internal class Reader: IReader
    {
        public string Read(string path) 
        {
            using (StreamReader stream = new(path)) 
            {
                return stream.ReadToEnd();
            }
        }
    }
}
