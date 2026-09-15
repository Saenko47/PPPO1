using PaterniLab1.Task1.Interfaces;
using PaterniLab1.Task1.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task1.Realization
{
    internal class PersonReportGeneretor: IReportGeneretor<Person> 
    {
        public void GenerateReport(List<Person> items) 
        {
            foreach (var item in items) 
            {
                Console.WriteLine($"First Name:{item.FirstName} \n" +
                    $"Last Name: {item.LastName} \n" +
                    $"Date Of Birth: {item.DateOfBirth} \n" +
                    $"Phone number: {item.PhoneNumber} \n" +
                    $"Email: {item.Email}");
            }
        }
    }
}
