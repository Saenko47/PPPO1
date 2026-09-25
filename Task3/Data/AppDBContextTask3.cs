using Microsoft.EntityFrameworkCore;
using PaterniLab1.Task2.Data;
using PaterniLab1.Task3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaterniLab1.Task3.Data
{
    internal class AppDBContextTask3:DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=appTask3.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>();
            modelBuilder.Entity<LicenseOfEmployee>();
            modelBuilder.Entity<Car>();
            modelBuilder.Entity<Voyage>();
            modelBuilder.Entity<LicenseOnCar>();

        }
    }
}
