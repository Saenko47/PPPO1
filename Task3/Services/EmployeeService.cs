using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using PaterniLab1.Task3.BaseClass;
using PaterniLab1.Task3.Models;
using PaterniLab1.Task3.Realization;
using PaterniLab1.Task3.Requests.EmployeeRequsts;
using PaterniLab1.Task3.Requests.Licence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task3.Services
{
    internal class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly LicenceOfEmployeeService _licenseService;



        public EmployeeService(EmployeeRepository employeeRepository, LicenceOfEmployeeService licenseService)
        {
            _employeeRepository = employeeRepository;
            _licenseService = licenseService;


        }

       

        public async Task CreateEmployeeByRequest(CreateEmployeeRequest request) 
        { 
            var employee = new Employee
            {
                Name = request.Name,
                Expirience = request.Expirience
            };

            await _employeeRepository.AddAsync(employee);

            var requetsToCreateLicense = new CreateLicenseOfEmployeeRequest { Employee = employee, Types = request.Licenses };

            await _licenseService.CreateLicenseForEmployeeByRequest(requetsToCreateLicense);

            await _employeeRepository.SaveChangesAsync();

        }

        public async Task<List<Employee>> FindEmployeeForWork(RequestOnFindingCandidate request) 
        {
            var workersWithLicenses = await _employeeRepository.GetWithLicensesAsync();

            if (workersWithLicenses.Count() == 0) throw new Exception("Theres no workers, sir");

            var suitableWorkers = workersWithLicenses.Where(w => w.IsUsingRigthNow == false && w.Expirience >= request.ExpirienceNedeed &&
             w.Licenses.Any(l => l.License.LicenseType == request.LicenseNeededForCandidate)
            ).ToList();
            return suitableWorkers;
        
        }

        public async Task SetEmployeeWorkStatus(int id, bool status) 
        {
            var employee = await _employeeRepository.GetById(id);
            if (employee == null) throw new Exception("Workers isnt find");
            employee.IsUsingRigthNow = status;
        }


    }
}
