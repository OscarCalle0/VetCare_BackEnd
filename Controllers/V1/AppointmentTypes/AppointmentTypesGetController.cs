using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VetCare_BackEnd.Controllers.V1.AppointmentTypes
{
    public partial class AppointmentTypesController
    {
        [HttpGet("getall")]
        public async Task<IActionResult> Get()
        {
            var AllAppointmentTypes = await _context.AppointmentTypes.ToListAsync();

            if (AllAppointmentTypes.Count() >= 1)
            {
                return Ok(AllAppointmentTypes);
            }

            else
            {
                return NotFound("any value found");
            }
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _context.AppointmentTypes.FirstOrDefaultAsync(ApTy => ApTy.Id == id);
            if (result == null)
            {
                return NotFound("Id not found");
            }
            return Ok(result);
        }

        [HttpGet("getbykeyword")]
        public async Task<IActionResult> GetByKeyword([FromQuery] string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return BadRequest("Keyword is required");
            }
            var appointmentTypes = await _context.AppointmentTypes.ToListAsync();

            var result = appointmentTypes.Where(ApTy => ApTy.Name.Contains(keyword, System.StringComparison.OrdinalIgnoreCase)).ToList();
            if (result.Count() == 0)
            {
                return NotFound("No roles found with that keyword");
            }
            return Ok(result);
        }
    }
}