using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VetCare_BackEnd.Controllers.V1.Roles;
public partial class RolesController
{
    /// <summary>
    /// Get all roles
    /// </summary>
    /// <returns>A list of all roles.</returns>
    /// <response code="200">Returns the list of roles.</response>
    /// <response code="404">If any value found</response>
    /// <response code="500">If there is a server error.</response>
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

    /// <summary>
    /// Get a role by ID
    /// </summary>
    /// <param name="id">The ID of the role to retrieve</param>
    /// <returns>The role with the specified ID.</returns>
    /// <response code="200">Returns the role found.</response>
    /// <response code="404">If the role is not found.</response>
    /// <response code="500">If there is a server error.</response>
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

    /// <summary>
    /// Get roles by keyword
    /// </summary>
    /// <param name="keyword">The keyword to search roles by</param>
    /// <returns>A list of roles that match the keyword.</returns>
    /// <response code="200">Returns the list of roles matching the keyword.</response>
    /// <response code="400">If the keyword is not provided or is invalid.</response>
    /// <response code="404">If no roles are found with the provided keyword.</response>
    /// <response code="500">If there is a server error.</response>
    [HttpGet("getbykeyword")]
    public async Task<IActionResult> GetByKeyword([FromQuery] string keyword)
    {
        if (string.IsNullOrEmpty(keyword))
        {
            return BadRequest("Keyword is required");
        }
        var roles = await _context.Roles.ToListAsync();

        var result = roles.Where(r => r.Name.Contains(keyword, System.StringComparison.OrdinalIgnoreCase)).ToList();
        if (result.Count() == 0)
        {
            return NotFound("No roles found with that keyword");
        }
        return Ok(result);
    }
}