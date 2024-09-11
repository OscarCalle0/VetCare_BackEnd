using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VetCare_BackEnd.Controllers.V1.Appointments;

public partial class AppointmentController
{
    [HttpGet("Pagination")]
    public async Task<IActionResult> Get(
    [FromQuery] int pageNumber = 1,
    [FromQuery] int pageSize = 10)
    {
         if (pageNumber < 1)
            {
                return BadRequest("the page number must be greated than or equal to 1");
            }
            if (pageSize < 1)
            {
                return BadRequest("the page size must be greated than or equal to 1.");
            }

        var Apointments = await _context.Appointments
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();
        if(Apointments.Count() < 1)
        {
            return BadRequest("Any data found");
        }
        
        return Ok(Apointments);
    }
}