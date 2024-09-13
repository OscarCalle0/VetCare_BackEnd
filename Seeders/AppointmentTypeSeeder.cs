using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Seeders
{
    public class AppointmentTypeSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentType>().HasData(
                new AppointmentType { Id = 1, Name = "consult"},
                new AppointmentType { Id = 2, Name = "exam"},
                new AppointmentType { Id = 3, Name = "appointment"}
            );
        }
    }
}