
using Microsoft.AspNetCore.Mvc;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Controllers.V1;

public partial class UserController 
{
    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="newUser">The information required to create the new user.</param>
    /// <returns>A success message confirming the creation of the user.</returns>


        [HttpPost("create")]
        public async Task<IActionResult> Create(User newUser)
        {
            _userService.Users.Add(newUser);
            await _userService.SaveChangesAsync();
            return Ok("usuario creado");
        }


    }
