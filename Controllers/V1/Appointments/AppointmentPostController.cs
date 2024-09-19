using Microsoft.AspNetCore.Mvc;
using VetCare_BackEnd.Models;
using VetCare_BackEnd.Models.Dtos;
using System;
using System.Threading.Tasks;

namespace VetCare_BackEnd.Controllers.V1.Appointments
{
    public partial class AppointmentController
    {
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

            // Validate that the time is within the allowed range (08:00 AM - 08:00 PM)
            var startTime = new TimeSpan(8, 0, 0); // 08:00 AM
            var endTime = new TimeSpan(20, 0, 0); // 08:00 PM

            // Validate if the EndDate time is within the allowed working hours
            if (request.EndDate.TimeOfDay < startTime || request.EndDate.TimeOfDay > endTime)
            {
                return BadRequest("Appointments can only be scheduled between 08:00 AM and 08:00 PM.");
            }

            // Validate if the EndDate is in the future
            if (request.EndDate <= DateTime.Now)
            {
                return BadRequest("EndDate must be a future date.");
            }

            // Create the new appointment
            var appointment = new Appointment
            {
                PetId = request.PetId,
                AppointmentTypeId = request.AppointmentTypeId,
                StartDate = DateTime.Now, // System's automatic date
                EndDate = request.EndDate,
                Available = DateTime.Now <= request.EndDate, // Logic to determine availability
                Description = request.Description
            };

            // Save the appointment in the database
            await _appointmentService.CreateAppointmentAsync(appointment);

            // Create the response DTO
            var response = new AppointmentResponseDto
            {
                StartDate = appointment.StartDate,
                EndDate = appointment.EndDate,
                Available = appointment.Available,
                Description = appointment.Description,
                PetId = appointment.PetId,
                AppointmentTypeId = appointment.AppointmentTypeId
            };

            return Ok(response);
        }
    }
}
