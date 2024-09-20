using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Seeders
{
    public class RoleSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin"},
                new Role { Id = 2, Name = "User"}
            );
        }
    }
}