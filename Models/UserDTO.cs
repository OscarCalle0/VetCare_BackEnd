using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetCare_BackEnd.Models;

public class UserDTO
{

    public required string Name { get; set; }
    public required string LastName { get; set; }
    public DateOnly? BirthDate { get; set; }
    public required string DocumentNumber { get; set; }
    public required string Password { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public int DocumentType_id { get; set; }
    public int Role_id { get; set; }

}
