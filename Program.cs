using Microsoft.EntityFrameworkCore;
using PaterniLab1.Task1;
using PaterniLab1.Task1.Data;
using PaterniLab1.Task1.Interfaces;
using PaterniLab1.Task1.Model;
using PaterniLab1.Task1.Realization;
using PaterniLab1.Task1.Tools;
using PaterniLab1.Task3.BaseClass;
using PaterniLab1.Task3.Data;
using PaterniLab1.Task3.Interfaces;
using PaterniLab1.Task3.Interfaces.Services;
using PaterniLab1.Task3.Models;
using PaterniLab1.Task3.Realization;
using PaterniLab1.Task3.Repositorys;
using PaterniLab1.Task3.Requests.CarRequest;
using PaterniLab1.Task3.Requests.EmployeeRequsts;
using PaterniLab1.Task3.Services;
using PaterniLab1.Task3.Tools;
using System.DirectoryServices;
using static PaterniLab1.Task3.Tools.Enums;

namespace PaterniLab1
{
    internal class Program
    {
        public static void Task1()
        {
            var dbContext = new AppDBContextTask1();

            dbContext.Database.EnsureCreated();

            var parseTemplate = new BaseParseTemplate<Person>(
         new GetPathByDialog(),
         new Reader(),
         new PersonParser(new PersonDeserializator()),
         new PersonValidator(),
         new PersonRepository(dbContext),
         new PersonReportGeneretor()
     );
            Console.WriteLine("Lets start");
            parseTemplate.ParseFromFile();
        }
        public static async Task CreateSomeLicense() 
        {
            var dbContext = new AppDBContextTask3();

            dbContext.Database.EnsureCreated();

            var liceRepo = new BaseRepositoryTask3<LicenseOnCar>(dbContext);

            await liceRepo.AddAsync(new LicenseOnCar { LicenseType = LicenceType.C });
            await liceRepo.AddAsync(new LicenseOnCar { LicenseType = LicenceType.B });
            await liceRepo.AddAsync(new LicenseOnCar { LicenseType = LicenceType.ADR });
            await liceRepo.AddAsync(new LicenseOnCar { LicenseType = LicenceType.C1 });

            await liceRepo.SaveChangesAsync();
        }


        public static async Task CreateSomeEmployeeForTask3() 
        {
            var dbContext = new AppDBContextTask3();

            dbContext.Database.EnsureCreated();

            IEmployeeRepository employeeRepository = new EmployeeRepository(dbContext);
            ICreateLicenseForEmployeeByRequest createLice = new LicenceOfEmployeeService(new BaseRepositoryTask3<LicenseOfEmployee>(dbContext), new LicenceRepository(dbContext));

            IEmployeeServices employeeServices = new EmployeeService(employeeRepository, createLice);

            var reqToCreateEmp1 = new CreateEmployeeRequest { Name = "Test1", Expirience = 10, Licenses = new List<LicenceType>() { LicenceType.C, LicenceType.B } };
            var reqToCreateEmp2 = new CreateEmployeeRequest { Name = "Test2", Expirience = 5, Licenses = new List<LicenceType>() { LicenceType.B, LicenceType.ADR } };
            var reqToCreateEmp3 = new CreateEmployeeRequest { Name = "Test3", Expirience = 5, Licenses = new List<LicenceType>() { LicenceType.C1 } };

            await employeeServices.CreateEmployeeByRequest(reqToCreateEmp1);
            await employeeServices.CreateEmployeeByRequest(reqToCreateEmp2);
            await employeeServices.CreateEmployeeByRequest(reqToCreateEmp3);
        }
        public static async Task CreateSomeCarForTask3()
        {
            var dbContext = new AppDBContextTask3();

            dbContext.Database.EnsureCreated();
            ICarService carService = new CarService(new BaseRepositoryTask3<Car>(dbContext));

            await carService.CreateCarByRequest(new CarCreateRequst { Title = "Test1", LincenseNeedsToDrive = LicenceType.B, MaxWeight = 100 });
            await carService.CreateCarByRequest(new CarCreateRequst { Title = "Test2", LincenseNeedsToDrive = LicenceType.ADR, MaxWeight = 50 });
            await carService.CreateCarByRequest(new CarCreateRequst { Title = "Test1", LincenseNeedsToDrive = LicenceType.C1, MaxWeight = 150 });

            var car = new BaseRepositoryTask3<Car>(dbContext);
            await car.SaveChangesAsync();


        }
        public static async Task Task3() 
        {
            var dbContext = new AppDBContextTask3();

            dbContext.Database.EnsureCreated();
            IEmployeeRepository employeeRepository = new EmployeeRepository(dbContext);
            ICreateLicenseForEmployeeByRequest createLice = new LicenceOfEmployeeService(new BaseRepositoryTask3<LicenseOfEmployee>(dbContext), new LicenceRepository(dbContext));

            EmployeeService employeeServices = new EmployeeService(employeeRepository, createLice);
            CarService carService = new CarService(new BaseRepositoryTask3<Car>(dbContext));

            IVoyageService voyageService = new VoyageService(new BaseRepositoryTask3<Voyage>(dbContext),
               carService, employeeServices);
            
            ISimulation simulation = new Simulation(voyageService, carService, employeeServices, new BaseRepositoryTask3<Car>(dbContext), employeeRepository);

            await simulation.SimulateWork();


        }
        [STAThread]
        static async Task Main(string[] args)
        {
            await Task3();
        }
    }
}
