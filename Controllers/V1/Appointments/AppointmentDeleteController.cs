using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VetCare_BackEnd.Controllers.V1.Appointments;
public partial class AppointmentController
{

/// <summary>
        /// Deletes an existing appointment by ID.
        /// </summary>
        /// <param name="id">The ID of the appointment to delete.</param>
        /// <returns>A response indicating the result of the deletion.</returns>
        /// <response code="200">Returns a message indicating successful deletion.</response>
        /// <response code="404">If the appointment is not found.</response>
        /// <response code="500">If there is a server error.</response>
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