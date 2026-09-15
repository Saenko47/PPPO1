using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task1.Model
{
    [PrimaryKey(nameof(Id))]
    internal class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public DateTime DateOfBirth { get; set; } 
        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;


    }
}
