using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task1.Interfaces
{
    internal interface IDeserializator<T> where T : class
    {
        public List<T> DeserealizeJson(string json);
        public List<T> DeserealizeXML(string xml);
        public List<T> DeserealizeCSV(string csv);
    }
}
