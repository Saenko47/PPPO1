using PaterniLab1.Task3.Models;
using PaterniLab1.Task3.Requests.EmployeeRequsts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task3.Interfaces.Services
{
    internal interface IEmployeeServices
    {
        Task CreateEmployeeByRequest(CreateEmployeeRequest request);
        Task<List<Employee>> FindEmployeeForWork(RequestOnFindingCandidate request);
    }
}
