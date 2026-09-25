using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PaterniLab1.Task3.Models
{
    [PrimaryKey(nameof(EmployeeId), nameof(LicenseId))]
    internal class LicenseOfEmployee
    {
        public int EmployeeId { get; set; }
        public int LicenseId { get; set; }

        public Employee Employee { get; set; } = null!;
        public LicenseOnCar License { get; set; } = null!;
    }
}
