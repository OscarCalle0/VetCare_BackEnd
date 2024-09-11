using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VetCare_BackEnd.Controllers.V1.Roles;
public partial class RolesController
{  
    [HttpGet("getall")]
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

    [HttpGet("getbyid/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var result = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
        if (result == null)
        {
            return NotFound("Id not found");
        }
        return Ok(result);
    }

    [HttpGet("getbykeyword")]
    public async Task<IActionResult> GetByKeyword([FromQuery] string keyword)
    {
        if(string.IsNullOrEmpty(keyword))
        {
            return BadRequest("Keyword is required");
        }
        var roles = await _context.Roles.ToListAsync();

        var result = roles.Where(r => r.Name.Contains(keyword, System.StringComparison.OrdinalIgnoreCase)).ToList();
        if(result.Count() == 0)
        {
            return NotFound("No roles found with that keyword");
        }
        return Ok(result);
    }
}