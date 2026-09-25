using Microsoft.EntityFrameworkCore;
using PaterniLab1.Task3.BaseClass;
using PaterniLab1.Task3.Data;
using PaterniLab1.Task3.Interfaces;
using PaterniLab1.Task3.Models;
using PaterniLab1.Task3.Requests.Licence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task3.Realization
{
    internal class EmployeeRepository: BaseRepositoryTask3<Employee>, IEmployeeRepository
    {
       
        public EmployeeRepository(AppDBContextTask3 context) : base(context)
        {
           
        }

        public async Task<List<Employee>> GetWithLicensesAsync()
        {

            return await _context
                .Include(e => e.Licenses)
                    .ThenInclude(l => l.License)
                    .ToListAsync();
               
        }


    }
}
