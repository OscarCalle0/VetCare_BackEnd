using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetCare_BackEnd.Models.Dtos
{
    public class UpdateUserDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string DocumentNumber { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int DocumentTypeId { get; set; }
        public int RoleId { get; set; }
    }
}