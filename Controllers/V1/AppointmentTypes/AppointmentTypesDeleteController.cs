using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VetCare_BackEnd.Controllers.V1.AppointmentTypes
{
    public partial class AppointmentTypesController
    {
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var appointmentType = await _context.AppointmentTypes.FindAsync(id);
            if (appointmentType == null)
            {
                return NotFound();
            }
            _context.AppointmentTypes.Remove(appointmentType);
            await _context.SaveChangesAsync();
            return Ok($"Role {appointmentType.Name} has been deleted");
        }
    }
}