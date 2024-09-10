using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VetCare_BackEnd.Controllers.V1.Roles;
public partial class RolesController
{  
    [HttpGet()]
    public async Task<IActionResult> Get()
    {
        var AllRoles = await _context.Roles.ToListAsync();

        if (AllRoles.Count() >= 1)
        {
            return Ok(AllRoles);
        }

        else
        {
            return NotFound("any value found");
        }
    }
}