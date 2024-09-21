using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Controllers.V1.AppointmentTypes
{
    public partial class AppointmentTypesController
    {

        /// <summary>
        /// Update the name of an appointment type by ID
        /// </summary>
        /// <param name="id">The ID of the appointment type to update</param>
        /// <param name="newAppointmentType">The appointment type object containing the updated name</param>
        /// <returns>A response indicating the result of the update.</returns>
        /// <response code="200">Returns a message indicating the appointment type was successfully updated.</response>
        /// <response code="400">If the input data is invalid.</response>
        /// <response code="404">If the appointment type with the specified ID is not found.</response>
        /// <response code="500">If there is a server error.</response>
        [HttpPatch("updateName/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AppointmentType newAppointmentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appointment = await _context.AppointmentTypes.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            appointment.Name = newAppointmentType.Name;
            await _context.SaveChangesAsync();
            return Ok("Role updated successfully");
        }
    }
}