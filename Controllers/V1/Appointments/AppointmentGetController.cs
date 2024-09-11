using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VetCare_BackEnd.Controllers.V1.Appointments;

public partial class AppointmentController
{
    [HttpGet("getall")]
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

    [HttpGet("getbyid/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var Appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);
        if(Appointment == null)
        {
            return NotFound("Appointment not found");
        }
        return Ok(Appointment);
    }

    [HttpGet("getbykeyword")]
    public async Task<IActionResult> GetByKeyword([FromQuery] string keyword)
    {
        if(string.IsNullOrEmpty(keyword))
        {
            return BadRequest("Keyword is required");
        }

        var appointments = await _context.Appointments.ToListAsync();

        var result = appointments.Where(r => 
            !string.IsNullOrEmpty(r.Description) && r.Description.Contains(keyword, System.StringComparison.OrdinalIgnoreCase)).
        ToList();

        if(result.Count() == 0)
        {
            return NotFound("No roles found with that keyword");
        }
        return Ok(result);
    }
}