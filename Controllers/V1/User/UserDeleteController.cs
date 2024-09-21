using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.CRUD;
using VetCare_BackEnd.Data;

namespace VetCare_BackEnd.Controllers.V1;


public partial class UserController
{
    /// <summary>
    ///  Delete a User
    /// </summary>
    /// <param name="id">The Id of the user you want to delete.</param>
    /// <returns>sucess when the user has been deleted.</returns>

    [HttpDelete]

    public async Task<ActionResult> Delete(int id)
    {
        var Usersearch = await _userService.Users.FindAsync(id);

        // Verifica si el usuario existe
        if (Usersearch == null)
        {
            return NotFound($"User with ID {id} not found.");
        }

        _userService.Users.Remove(Usersearch);
        _userService.SaveChanges();
        return Ok("The user has been deleted ");
    }

}




