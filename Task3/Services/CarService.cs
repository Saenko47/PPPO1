using PaterniLab1.Task3.BaseClass;
using PaterniLab1.Task3.Interfaces;
using PaterniLab1.Task3.Interfaces.Services;
using PaterniLab1.Task3.Models;
using PaterniLab1.Task3.Realization;
using PaterniLab1.Task3.Requests.CarRequest;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PaterniLab1.Task3.Services
{
    internal class CarService: IWorkStatus<Car>, ICarService
    {
        private readonly BaseRepositoryTask3<Car> _carRepository;

        public CarService(BaseRepositoryTask3<Car> carRepository    )
        {
            _carRepository = carRepository;
        }

        public async Task CreateCarByRequest(CarCreateRequst requst) 
        {
            await _carRepository.AddAsync(new Car { Title = requst.Title, LincenseNeedsToDrive = requst.LincenseNeedsToDrive, MaxWeight = requst.MaxWeight });
        }

        public async Task SetWorkStatus(int id, bool status) 
        {
            var car = await _carRepository.GetById(id);
            if (car == null) throw new Exception("Workers isnt find");
            car.IsUsingRigthNow = status;
        }

        public async Task<List<Car>> FindCarForWork(RequestOnFindingCar request) 
        {
            return _carRepository._context.Where(c => c.MaxWeight >= request.MaxWeight).ToList();

          
        } 
      
    }
}
