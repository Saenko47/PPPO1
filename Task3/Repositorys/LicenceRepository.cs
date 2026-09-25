using Microsoft.EntityFrameworkCore;
using PaterniLab1.Task3.BaseClass;
using PaterniLab1.Task3.Data;
using PaterniLab1.Task3.Interfaces;
using PaterniLab1.Task3.Models;
using PaterniLab1.Task3.Requests.Licence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using static PaterniLab1.Task3.Tools.Enums;



namespace PaterniLab1.Task3.Realization
{
    internal class LicenceRepository:BaseRepositoryTask3<LicenseOnCar>, IGetLicenseByTypes
    {

        public LicenceRepository(AppDBContextTask3 context) : base(context) { }

        public async Task<List<LicenseOnCar>> GetLicensesByTypesAsync(List<LicenceType> licenceTypes)
        {
            return await _context
                .Where(l => licenceTypes.Contains(l.LicenseType))
                .ToListAsync();
        }

    }
}
