using Microsoft.AspNetCore.Mvc;
using VetCare_BackEnd.Models;
using VetCare_BackEnd.Models.Dtos;

namespace VetCare_BackEnd.Controllers.V1.Appointments;
public partial class AppointmentController
{
    [HttpPost("create")]
    public async Task<IActionResult> Create(AppointmentDTO newAppointmentDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var appointment = new Appointment
        {
            StartDate = DateTime.Now,
            EndDate = newAppointmentDTO.EndDate,
            Available = newAppointmentDTO.Available,
            Description = newAppointmentDTO.Description,
            PetId = newAppointmentDTO.PetId,
            AppointmentTypeId = newAppointmentDTO.AppointmentTypeId
        };

        await _context.Appointments.AddAsync(appointment);
        await _context.SaveChangesAsync();
        return Ok("Appointment Added successfully");
    }
}
