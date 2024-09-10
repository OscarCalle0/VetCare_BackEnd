using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VetCare_BackEnd.Controllers.V1.Roles;
public partial class RolesController
{
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, string newRoleName)
    {
        if(string.IsNullOrEmpty(newRoleName))
        {
            return BadRequest("Role name cannot be empty");
        }

        var role = await _context.Roles.FindAsync(id);
        if(role == null)
        {
            return NotFound();
        }

        role.Name = newRoleName;
        await _context.SaveChangesAsync();
        return Ok("Role updated successfully");
    }
}