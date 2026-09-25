using PaterniLab1.Task3.Models;
using PaterniLab1.Task3.Requests.CarRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task3.Interfaces.Services
{
    internal interface ICarService
    {
        Task CreateCarByRequest(CarCreateRequst requst);
        Task<List<Car>> FindCarForWork(RequestOnFindingCar request);
    }
}
