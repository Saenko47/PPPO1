using PaterniLab1.Task3.BaseClass;
using PaterniLab1.Task3.Interfaces;
using PaterniLab1.Task3.Interfaces.Services;
using PaterniLab1.Task3.Models;
using PaterniLab1.Task3.Requests.CarRequest;
using PaterniLab1.Task3.Requests.EmployeeRequsts;
using PaterniLab1.Task3.Requests.VoyageRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task3.Tools
{
    internal class Simulation: ISimulation
    {
        private readonly IEmployeeServices _employeeServices;
        private readonly ICarService _carServices;
        private readonly IVoyageService _voyageService;
        private readonly BaseRepositoryTask3<Car> _carRepo;
        private readonly IEmployeeRepository _employeeRepo;
        
        public Simulation(
            IVoyageService voyageService, ICarService carService, IEmployeeServices employeeServices, BaseRepositoryTask3<Car> carRepo, IEmployeeRepository employeeRepo)
        {
            _voyageService = voyageService;
            _carServices = carService;
            _employeeServices = employeeServices;
            _carRepo = carRepo;
            _employeeRepo = employeeRepo;
        }

        public async Task SimulateWork()
        {
            Console.WriteLine("Lets select an Car for work");

            Console.WriteLine("Select weigth for car");

            int weigthToCar = int.Parse(Console.ReadLine());
            var carRequest = new RequestOnFindingCar { MaxWeight = weigthToCar };

            var fittbleCar = await _carServices.FindCarForWork(carRequest);

            foreach (var car in fittbleCar) 
            {
                Console.WriteLine($"id: {car.Id}, Title: {car.Title}, license nedeed: {car.LincenseNeedsToDrive}");
            }

            int selectedCarId = int.Parse(Console.ReadLine());

            var selectedCar = await _carRepo.GetById(selectedCarId);
            if (selectedCar == null) throw new Exception("???");


            var employeeRequest = new RequestOnFindingCandidate { LicenseNeededForCandidate = selectedCar.LincenseNeedsToDrive, ExpirienceNedeed = 0 };

            var fittbleEmployee = await _employeeServices.FindEmployeeForWork(employeeRequest);

            foreach (var emp in fittbleEmployee) 
            {
                Console.WriteLine($"Id: {emp.Id} Name: {emp.Name}");
            }
            int selectedEmployeeId = int.Parse(Console.ReadLine());

            var selectedEmployee = _employeeRepo.GetById(selectedEmployeeId);

            if(selectedEmployee == null) throw new Exception("???");

            var voyageRequest = new CreateVoyageRequest { CarId = selectedCar.Id, EmployeeId = selectedEmployee.Id };




            await _voyageService.CreateVoyage(voyageRequest);
            // Simulate closing a voyage
            Console.WriteLine("Starting voyage");
            await Task.Delay(5000); // Simulate some work being done
            await _voyageService.CloseVoyage(1);
        }
    }
}
