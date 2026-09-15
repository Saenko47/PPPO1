using Microsoft.EntityFrameworkCore;
using PaterniLab1.Task1.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task1.Data
{
    internal class AppDBContextTask1:DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=appTask1.db");
        }
    }
}
