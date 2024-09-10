using Microsoft.AspNetCore.Mvc;
using VetCare_BackEnd.Data;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Controllers.V1.Roles;
public partial class RolesController
{
    [HttpPost()]
    public async Task<IActionResult> Create(Role newRole)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _context.Roles.AddAsync(newRole);
        await _context.SaveChangesAsync();
        return Ok("Role Added successfully");
    }
}
