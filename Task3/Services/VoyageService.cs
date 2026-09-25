using PaterniLab1.Task3.BaseClass;
using PaterniLab1.Task3.Interfaces;
using PaterniLab1.Task3.Interfaces.Services;
using PaterniLab1.Task3.Models;
using PaterniLab1.Task3.Requests.VoyageRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task3.Services
{
    internal class VoyageService: IVoyageService
    {
        private readonly BaseRepositoryTask3<Voyage> _repo;

        private readonly IWorkStatus<Car> _carStatusChanger;
        private readonly IWorkStatus<Employee> _employeeStatusChanger;

        public VoyageService(BaseRepositoryTask3<Voyage> repo, IWorkStatus<Car> carStatusChanger, IWorkStatus<Employee> employeeStatusChanger)
        {
            _repo = repo;
            _carStatusChanger = carStatusChanger;
            _employeeStatusChanger = employeeStatusChanger;
        }

        public async Task CreateVoyage(CreateVoyageRequest request) 
        {
            if (request == null) throw new Exception();

            var newVoyage = new Voyage { EmployeeId = request.EmployeeId, CarId = request.CarId };

            await _employeeStatusChanger.SetWorkStatus(request.EmployeeId, true);
            await _carStatusChanger.SetWorkStatus(request.CarId, true);

            await _repo.AddAsync(newVoyage);
            await _repo.SaveChangesAsync();

        }

        public async Task CloseVoyage(int id) 
        {
            var voyageToClose = await _repo.GetById(id);
            if (voyageToClose == null) throw new Exception();
            voyageToClose.IsCompletedVoyage = true;

            await _employeeStatusChanger.SetWorkStatus(voyageToClose.EmployeeId, false);
            await _carStatusChanger.SetWorkStatus(voyageToClose.CarId, false);

            await _repo.SaveChangesAsync();
        }
    }
}
