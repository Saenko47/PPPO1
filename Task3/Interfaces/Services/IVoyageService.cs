using PaterniLab1.Task3.Requests.VoyageRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task3.Interfaces.Services
{
    internal interface IVoyageService
    {
        Task CreateVoyage(CreateVoyageRequest request);
        Task CloseVoyage(int id);
    }
}
