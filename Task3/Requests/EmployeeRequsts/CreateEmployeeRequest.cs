using PaterniLab1.Task3.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static PaterniLab1.Task3.Tools.Enums;

namespace PaterniLab1.Task3.Requests.EmployeeRequsts
{
    internal class CreateEmployeeRequest
    {
        public string Name { get; set; } = null!;
        public int Expirience { get; set; }

        public List<LicenceType> Licenses { get; set; } = new();
    }
}
