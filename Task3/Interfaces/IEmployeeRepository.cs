using PaterniLab1.Task3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task3.Interfaces
{
    internal interface IEmployeeRepository
    {
        Task<Employee?> GetById(int id);
        Task<List<Employee>> GetAll();
        void Delete(Employee entity);
        Task AddAsync(Employee entity);
        Task SaveChangesAsync();
        Task<List<Employee>> GetWithLicensesAsync();

    }
}
