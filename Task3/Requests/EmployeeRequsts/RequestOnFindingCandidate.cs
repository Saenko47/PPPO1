using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using static PaterniLab1.Task3.Tools.Enums;

namespace PaterniLab1.Task3.Requests.EmployeeRequsts
{
    internal class RequestOnFindingCandidate
    {
       public LicenceType LicenseNeededForCandidate { get; set; }

       public int ExpirienceNedeed { get; set; } 
    }
}
