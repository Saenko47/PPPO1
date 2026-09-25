using PaterniLab1.Task3.BaseClass;
using PaterniLab1.Task3.Interfaces;
using PaterniLab1.Task3.Interfaces.Services;
using PaterniLab1.Task3.Models;
using PaterniLab1.Task3.Realization;
using PaterniLab1.Task3.Requests.Licence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task3.Services
{
    internal class LicenceOfEmployeeService: ICreateLicenseForEmployeeByRequest
    {
        private readonly BaseRepositoryTask3<LicenseOfEmployee> _licenseOfEmployeeRepository;
        private readonly IGetLicenseByTypes _licenceRepository;

        public LicenceOfEmployeeService(BaseRepositoryTask3<LicenseOfEmployee> licenseRepo, IGetLicenseByTypes licenceRepository)
        {
            _licenseOfEmployeeRepository = licenseRepo;
            _licenceRepository = licenceRepository;
        }

        public async Task CreateLicenseForEmployeeByRequest(CreateLicenseOfEmployeeRequest request)
        {
            var licenses = await _licenceRepository.GetLicensesByTypesAsync(request.Types);

            if (licenses.Count != request.Types.Count)
            {
                throw new InvalidOperationException("Деякі із вказаних категорій ліцензій відсутні в базі даних.");
            }

            foreach (var license in licenses)
            {
                var newLicenseOfEmployee = new LicenseOfEmployee
                {
                    Employee = request.Employee, 
                    License = license
                };

                await _licenseOfEmployeeRepository.AddAsync(newLicenseOfEmployee);
            }
        }
    }
}
