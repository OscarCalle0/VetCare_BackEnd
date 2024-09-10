using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Seeders
{
    public class UserSeeder
    {
        public static List<User> GenerateUser(int UserQuantities)
        {
            var faker = new Faker<User>()
                .RuleFor(u => u.Id, f => f.IndexFaker + 1)
                .RuleFor(u => u.Name, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.BirthDate, f => f.Date.PastDateOnly())
                .RuleFor(u => u.DocumentNumber, f => f.Random.AlphaNumeric(10))
                .RuleFor(u => u.Password, f => f.Internet.Password())
                .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber("### ### ## ##"))
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.DocumentTypeId, f => f.Random.Number(1, 5))
                .RuleFor(u => u.RoleId, f => f.Random.Number(1, 5));
            
            return faker.Generate(UserQuantities);
        }
    }
}