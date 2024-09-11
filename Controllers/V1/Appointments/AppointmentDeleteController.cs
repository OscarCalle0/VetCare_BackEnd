using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VetCare_BackEnd.Controllers.V1.Appointments;
public partial class AppointmentController
{
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete( [FromRoute] int id)
    {
        var appointment = await _context.Appointments.FindAsync(id);
        if (appointment == null)
        {
            return NotFound();
        }
        _context.Appointments.Remove(appointment);
        await _context.SaveChangesAsync();
        return Ok($"Appointment {appointment.Id} has been deleted");
    }
}