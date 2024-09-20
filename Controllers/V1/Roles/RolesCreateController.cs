using Microsoft.AspNetCore.Mvc;
using VetCare_BackEnd.Data;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Controllers.V1.Roles;
public partial class RolesController
{
    /// <summary>
    /// Create a new role
    /// </summary>
    /// <returns>A response indicating the result of the role creation.</returns>
    /// <response code="200">Returns a message indicating successful creation.</response>
    /// <response code="400">If the input data is invalid.</response>
    /// <response code="500">If there is a server error.</response>
    [HttpPost("create")]
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
