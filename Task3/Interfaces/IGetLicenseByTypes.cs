using PaterniLab1.Task3.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static PaterniLab1.Task3.Tools.Enums;

namespace PaterniLab1.Task3.Interfaces
{
    internal interface IGetLicenseByTypes
    {
        Task<List<LicenseOnCar>> GetLicensesByTypesAsync(List<LicenceType> licenceTypes);
    }
}
