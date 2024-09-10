using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VetCare_BackEnd.Controllers.V1.Roles;
public partial class RolesController
{
    [HttpDelete("{id}")]
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
