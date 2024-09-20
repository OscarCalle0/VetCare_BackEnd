using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Controllers.V1.Appointments;
public partial class AppointmentController
{/// <summary>
 /// Updates an existing appointment by ID.
 /// </summary>
 /// <param name="id">The ID of the appointment to update.</param>
 /// <param name="updatedAppointment">The updated appointment details.</param>
 /// <returns>A response indicating the result of the update.</returns>
 /// <response code="200">Returns a message indicating successful update.</response>
 /// <response code="400">If the model state is invalid.</response>
 /// <response code="404">If the appointment is not found.</response>
 /// <response code="500">If there is a server error.</response>
    [HttpPut("updateAppointment/{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Appointment updatedAppointment)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var appointment = await _context.Appointments.FindAsync(id);
        if (appointment == null)
        {
            return NotFound();
        }
        appointment.StartDate = updatedAppointment.StartDate;
        appointment.EndDate = updatedAppointment.EndDate;
        appointment.Available = updatedAppointment.Available;
        appointment.Description = updatedAppointment.Description;
        appointment.PetId = updatedAppointment.PetId;
        appointment.AppointmentTypeId = updatedAppointment.AppointmentTypeId;

        await _context.SaveChangesAsync();
        return Ok("Appointment updated successfully");
    }
}
