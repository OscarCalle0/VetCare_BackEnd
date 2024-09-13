using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Seeders
{
    public class PetSeeder
    {
     public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().HasData(
                new Pet { Id = 2, Name = "apolo", Breed = "yorkie", Weight = "10lbs", BirthDate = new DateOnly(2024, 02, 9), Sex = "male", user_id = 1},
                new Pet { Id = 3, Name = "princesa", Breed = "border colie", Weight = "7lbs", BirthDate = new DateOnly(2024, 03, 12), Sex = "female", user_id = 2},
                new Pet { Id = 4, Name = "cookie", Breed = "pomerania", Weight = "3lbs", BirthDate = new DateOnly(2024, 04, 23), Sex = "male", user_id = 3},
                new Pet { Id = 5, Name = "motas", Breed = "bulldog", Weight = "12lbs", BirthDate = new DateOnly(2024, 05, 4), Sex = "female", user_id = 4},
                new Pet { Id = 6, Name = "coco", Breed = "creole", Weight = "6lbs", BirthDate = new DateOnly(2024, 06, 3), Sex = "male", user_id = 5},
                new Pet { Id = 7, Name = "romeo", Breed = "creole", Weight = "8lbs", BirthDate = new DateOnly(2024, 07, 2), Sex = "female", user_id = 6},
                new Pet { Id = 8, Name = "kira", Breed = "yorkie", Weight = "9lbs", BirthDate = new DateOnly(2024, 08, 1), Sex = "male", user_id = 7}
            );
        }   
    }
}