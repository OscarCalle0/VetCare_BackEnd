using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Controllers.V1.Appointments;
public partial class AppointmentController
{
    [HttpPut("{id}")]
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
