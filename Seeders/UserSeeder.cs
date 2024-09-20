using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Seeders
{
    public class UserSeeder
    {
        public static void GenerateUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "oscar", LastName = "calle", BirthDate = new DateOnly(1997, 03, 18), Email = "oscarcalle0@gmail.com", PhoneNumber = "3195588904", DocumentNumber = "1128463678", DocumentTypeId = 1, Password = "1234", RoleId = 1},
                new User { Id = 2, Name = "mariana", LastName = "perez", BirthDate = new DateOnly(2003, 10, 22), Email = "mperezserna8@gmail.com", PhoneNumber = "3008387411", DocumentNumber = "1000537869", DocumentTypeId = 1, Password = "1234", RoleId = 1},
                new User { Id = 3, Name = "jhon", LastName = "asprilla", BirthDate = new DateOnly(2004, 01, 04), Email = "asprillajhon73@gmail.com", PhoneNumber = "3053307402", DocumentNumber = "1013456232", DocumentTypeId = 1, Password = "1234", RoleId = 1}
                
            );
        }
    }
}