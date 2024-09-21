using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Controllers.V1.Roles;
public partial class RolesController
{
    
    /// <summary>
    /// Update the name of a role by ID
    /// </summary>
    /// <param name="id">The ID of the role to update</param>
    /// <param name="newRole">The role object containing the updated name</param>
    /// <returns>A response indicating the result of the update.</returns>
    /// <response code="200">Returns a message indicating the role was successfully updated.</response>
    /// <response code="400">If the input data is invalid.</response>
    /// <response code="404">If the role with the specified ID is not found.</response>
    /// <response code="500">If there is a server error.</response>
    [HttpPatch("updateName/{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Role newRole)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var role = await _context.Roles.FindAsync(id);

        if (role == null)
        {
            return NotFound();
        }

        role.Name = newRole.Name;
        await _context.SaveChangesAsync();
        return Ok("Role updated successfully");
    }
}