using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task3.Models
{
    [PrimaryKey(nameof(Id))]
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public bool IsUsingRigthNow { get; set; } = false;

        public int Expirience { get; set; } = 0;

        public List<LicenseOfEmployee> Licenses { get; set; } = new();

    }
}
