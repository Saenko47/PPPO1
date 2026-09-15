using PaterniLab1.Task1.Interfaces;
using PaterniLab1.Task1.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task1.Realization
{
    internal class PersonValidator:IValidator<Person>
    {
        public bool Validate(Person item)
        {
            if (item == null)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(item.FirstName) || string.IsNullOrWhiteSpace(item.LastName))
            {
                return false;
            }
            if (item.DateOfBirth == null || item.DateOfBirth > DateTime.Now)
            {
                return false;
            }
            if(string.IsNullOrEmpty(item.Email))
            {
                return false;
            }
            if(string.IsNullOrEmpty(item.PhoneNumber))
            {
                return false;
            }
            return true;
        }
    }
}
