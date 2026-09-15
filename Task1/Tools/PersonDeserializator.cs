using PaterniLab1.Task1.Interfaces;
using PaterniLab1.Task1.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace PaterniLab1.Task1.Tools
{
    internal class PersonDeserializator:IDeserializator<Person>
    {
        public List<Person> DeserealizeCSV(string csv)
        {
            return new List<Person>();
        }
        public List<Person> DeserealizeJson(string json)
        {
            if (string.IsNullOrWhiteSpace(json)) return new List<Person>();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true 
            };

            return JsonSerializer.Deserialize<List<Person>>(json, options) ?? new List<Person>();
        }

       
        public List<Person> DeserealizeXML(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml)) return new List<Person>();

            
            var serializer = new XmlSerializer(typeof(List<Person>));
            using var reader = new StringReader(xml);

            return (List<Person>?)serializer.Deserialize(reader) ?? new List<Person>();
        }
    }
}
