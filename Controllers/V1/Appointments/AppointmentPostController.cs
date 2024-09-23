using Microsoft.AspNetCore.Mvc;
using VetCare_BackEnd.Models;
using VetCare_BackEnd.Models.Dtos;
using System;
using System.Threading.Tasks;
using VetCare_BackEnd.Services.Interfaces;
using VetCare_BackEnd.Services;

namespace VetCare_BackEnd.Controllers.V1.Appointments
{
    public partial class AppointmentController
    {
        /// <summary>
        /// Creates a new appointment.
        /// </summary>
        /// <remarks>
        /// This endpoint allows authenticated users to create a new appointment. 
        /// The user and pet must exist in the system, and the appointment 
        /// must be scheduled within working hours (08:00 AM - 08:00 PM).
        /// </remarks>
        /// <param name="request">The appointment request DTO containing user, pet, and appointment details.</param>
        /// <returns>Returns the created appointment details.</returns>
        /// <response code="200">Returns the created appointment details.</response>
        /// <response code="400">If the user or pet is invalid, or if the appointment time is out of range.</response>
        /// <response code="500">If there is a server error.</response>
        [HttpPost("create")]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentRequestDto request)
        {
            // Check if the user and pet exist
            var user = await _userService.GetUserByIdAsync(request.UserId);
            var pet = await _petService.GetPetByIdAsync(request.PetId);

            if (user == null || pet == null)
            {
                return BadRequest("Invalid user or pet.");
            }

            // Validate that the appointment time is within working hours
            var startTime = new TimeSpan(8, 0, 0); // 08:00 AM
            var endTime = new TimeSpan(20, 0, 0); // 08:00 PM

            if (request.EndDate.TimeOfDay < startTime || request.EndDate.TimeOfDay > endTime)
            {
                return BadRequest("Appointments can only be scheduled between 08:00 AM and 08:00 PM.");
            }

            if (request.EndDate <= DateTime.UtcNow.AddHours(-5.5)) // Ajuste de 5:30 horas
            {
                return BadRequest("EndDate must be a future date.");
            }

            // Obtener el tipo de cita
            AppointmentType appointmentType = await _appointmentTypeService.GetAppointmentTypeByIdAsync(request.AppointmentTypeId);

            if (appointmentType == null)
            {
                return BadRequest("Invalid appointment type.");
            }

            // Create the new appointment
            var appointment = new Appointment
            {
                PetId = request.PetId,
                AppointmentTypeId = request.AppointmentTypeId,
                StartDate = DateTime.UtcNow.AddHours(-5.5), // Ajuste de 5:30 horas
                EndDate = request.EndDate.ToUniversalTime(), // Guardar en UTC
                Available = DateTime.UtcNow.AddHours(-5.5) <= request.EndDate.ToUniversalTime(),
                Description = request.Description,
                AppointmentType = appointmentType
            };

            await _appointmentService.CreateAppointmentAsync(appointment);

            // Send notification email
            await _emailService.SendAppointmentNotificationEmail(user.Email, pet.Name, appointment);

            // Create response DTO
            var response = new AppointmentResponseDto
            {
                StartDate = appointment.StartDate,
                EndDate = appointment.EndDate,
                Available = appointment.Available,
                Description = appointment.Description,
                PetId = appointment.PetId,
                AppointmentTypeId = appointment.AppointmentTypeId,
                PetName = pet.Name,
                AppointmentType = appointmentType?.Name
            };

            return Ok(response);
        }
    }
}
