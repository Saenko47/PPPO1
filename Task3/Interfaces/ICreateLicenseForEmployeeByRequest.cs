using PaterniLab1.Task3.Requests.Licence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task3.Interfaces
{
    internal interface ICreateLicenseForEmployeeByRequest
    {
        Task CreateLicenseForEmployeeByRequest(CreateLicenseOfEmployeeRequest request);
    }
}
