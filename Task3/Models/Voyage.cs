using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task3.Models
{
    [PrimaryKey(nameof(Id))]
    internal class Voyage
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int EmployeeId { get; set; }

        public bool IsCompleted { get; set; } = false;

        public Car Car { get; set; } = new();
        public Employee Employee { get; set; } = new();


    }
}
