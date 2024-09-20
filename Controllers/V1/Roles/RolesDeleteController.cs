using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VetCare_BackEnd.Controllers.V1.Roles;
public partial class RolesController
{
    /// <summary>
    /// Delete a role by ID
    /// </summary>
    /// <param name="id">The ID of the role to delete</param>
    /// <returns>A response indicating the result of the deletion.</returns>
    /// <response code="200">Returns a message indicating successful deletion.</response>
    /// <response code="404">If the role is not found.</response>
    /// <response code="500">If there is a server error.</response>
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var role = await _context.Roles.FindAsync(id);
        if (role == null)
        {
            return NotFound();
        }
        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
        return Ok($"Role {role.Name} has been deleted");
    }
}
