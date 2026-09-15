using System;
using System.Collections.Generic;
using System.Text;
using static PaterniLab1.Task3.Tools.Enums;

namespace PaterniLab1.Task3.Models
{
    internal class LicenseOnCar
    {
        public int Id { get; set; }
        public LicenceType LicenseType { get; set; }

        public List<LicenseOfEmployee> Employees { get; set; } = new();
    }
}
