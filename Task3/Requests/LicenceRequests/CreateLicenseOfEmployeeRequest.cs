using PaterniLab1.Task3.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static PaterniLab1.Task3.Tools.Enums;

namespace PaterniLab1.Task3.Requests.Licence
{
    internal class CreateLicenseOfEmployeeRequest
    {
        public Employee Employee { get; set; } = null!;
        public List<LicenceType> Types { get; set; } = null!;    
    }
}
