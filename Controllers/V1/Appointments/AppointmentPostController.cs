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
        /// The user and pet must exist in the system.
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
                StartDate = DateTime.Now,
                EndDate = request.EndDate,
                Available = DateTime.Now <= request.EndDate,
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
