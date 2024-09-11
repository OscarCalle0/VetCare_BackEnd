using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Controllers.V1.Roles;
public partial class RolesController
{
    [HttpPatch("UpdateName/{id}")]
    public async Task<IActionResult> Update([FromRoute] int id,[FromBody] Role newRole)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var role = await _context.Roles.FindAsync(id);

        if(role == null)
        {
            return NotFound();
        }

        role.Name = newRole.Name;
        await _context.SaveChangesAsync();
        return Ok("Role updated successfully");
    }
}