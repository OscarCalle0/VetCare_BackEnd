
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetCare_BackEnd.Models;
using VetCare_BackEnd.Models.Dtos;

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
        if (newUser == null)
        {
            return BadRequest("Invalid user data.");
        }

        var existingUser = await _userService.Users.FirstOrDefaultAsync(u => u.Email == newUser.Email);
        if (existingUser != null)
        {
            return Conflict("A user with the same email already exists.");
        }
        _userService.Users.Add(newUser);
        await _userService.SaveChangesAsync();
        return Ok("usuario creado");
    }
}
