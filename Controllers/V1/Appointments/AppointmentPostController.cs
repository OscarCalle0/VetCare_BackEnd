using Microsoft.AspNetCore.Mvc;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Controllers.V1.Appointments;
public partial class AppointmentController
{
    [HttpPost("create")]
    public async Task<IActionResult> Create(Appointment newAppointment)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _context.Appointments.AddAsync(newAppointment);
        await _context.SaveChangesAsync();
        return Ok("Appointment Added successfully");
    }
}
