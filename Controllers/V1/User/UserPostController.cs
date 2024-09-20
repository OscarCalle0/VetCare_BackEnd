
using Microsoft.AspNetCore.Mvc;
using VetCare_BackEnd.Models;
using VetCare_BackEnd.Models.Dtos;

namespace VetCare_BackEnd.Controllers.V1;

    public partial class UserController 
    {
        

        [HttpPost("create")]
        public async Task<IActionResult> Create(UserDTO newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                Name = newUser.Name,
                LastName = newUser.LastName,
                BirthDate = newUser.BirthDate,
                DocumentNumber = newUser.DocumentNumber,
                Password = newUser.Password,
                PhoneNumber = newUser.PhoneNumber,
                Email = newUser.Email,
                DocumentTypeId = newUser.DocumentTypeId,
                RoleId = newUser.RoleId,
            };

            _userService.Users.Add(user);
            await _userService.SaveChangesAsync();
            return Ok("user created successfully");
        }
    }
