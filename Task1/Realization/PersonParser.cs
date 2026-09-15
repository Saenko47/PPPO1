using PaterniLab1.Task1.Interfaces;
using PaterniLab1.Task1.Model;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using static PaterniLab1.Task1.Tools.Enums;

namespace PaterniLab1.Task1.Realization
{
    internal class PersonParser:IParser<Person>
    {
        private readonly IDeserializator<Person> _deserializator;
        public PersonParser(IDeserializator<Person> deserializator) 
        {
            _deserializator = deserializator;
        }

        private List<Person> ChooseDeserialization(string rawData, TypeOfData typeOfData) 
        {
            List<Person> persons = new List<Person>();
            switch (typeOfData) 
            {
                case TypeOfData.json:
                    persons = _deserializator.DeserealizeJson(rawData);
                    break;
                case TypeOfData.xml:
                    persons = _deserializator.DeserealizeXML(rawData);
                    break;
                case TypeOfData.csv:
                    persons = _deserializator.DeserealizeCSV(rawData);
                    break;

            }
            return persons;
        }

        public List<Person> Parse(string rawData, TypeOfData typeOfData) 
        {
            if (_deserializator == null) throw new Exception("Deserializator is null!!!");

            return ChooseDeserialization(rawData, typeOfData);

           

        }
    }
}
