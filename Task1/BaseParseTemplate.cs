using PaterniLab1.Task1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static PaterniLab1.Task1.Tools.Enums;

namespace PaterniLab1.Task1
{
    internal class BaseParseTemplate<T> where T: class
    {
        private readonly IGetPath _getPath;
        private readonly IReader _reader;
        private readonly IParser<T> _parser;
        private readonly IValidator<T> _validator;
        private readonly IRepository<T> _repository;
        private readonly IReportGeneretor<T> _reportGeneretor;


        public BaseParseTemplate(IGetPath getPath, IReader reader, IParser<T> parser, IValidator<T> validator, IRepository<T> repository, IReportGeneretor<T> reportGeneretor)
        {
            _getPath = getPath;
            _reader = reader;
            _parser = parser;
            _validator = validator;
            _repository = repository;
            _reportGeneretor = reportGeneretor;
        }

        private void CheckForExceptions() 
        {
            if (_getPath == null) throw new Exception("getPath is null!!");
            if (_reader == null) throw new Exception("reader is null!!");
            if (_parser == null) throw new Exception("parser is null!!");
            if (_validator == null) throw new Exception("validor is null!!");
            if (_repository == null) throw new Exception("repository is null!!!");
            if (_reportGeneretor == null) throw new Exception("report generetor is null!!");
        }

        private TypeOfData GetTypeOfData(string path) 
        {
            TypeOfData typeOfData;
            if(path.EndsWith(".json")) typeOfData = TypeOfData.json;
            else if(path.EndsWith(".xml")) typeOfData = TypeOfData.xml;
            else if(path.EndsWith(".csv")) typeOfData = TypeOfData.csv;
            else throw new Exception("Unsupported file type!!!");
            return typeOfData;
        }

        private void Parse() 
        {
        
            string path = _getPath.GetPath();
            if (string.IsNullOrEmpty(path)) throw new Exception("path is empty!!!");

            string rawData = _reader.Read(path);
            if (string.IsNullOrEmpty(rawData)) throw new Exception("file is empty!!");

            var typeOfData = GetTypeOfData(path);

            var parsedData = _parser.Parse(rawData, typeOfData);
            if (parsedData == null) throw new Exception("Something goes wrong in parse side");

           

            List<T> dataToAddToDB = new List<T>();
            foreach (var data in parsedData) 
            {
                if (_validator.Validate(data)) dataToAddToDB.Add(data); 
            }

            _repository.Save(dataToAddToDB);

            _reportGeneretor.GenerateReport(dataToAddToDB);

        }

        public void ParseFromFile() 
        {
            CheckForExceptions();
            Parse();
        }
    }
}
