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

        public bool IsCompletedVoyage { get; set; } = false;

        public Car Car { get; set; } = null!;
        public Employee Employee { get; set; } = null!;


    }
}
