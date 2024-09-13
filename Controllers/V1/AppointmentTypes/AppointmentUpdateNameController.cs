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