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
        /// <summary>
        /// Get all appointment types
        /// </summary>
        /// <returns>A list of all appointment types.</returns>
        /// <response code="200">Returns the list of appointment types.</response>
        /// <response code="404">If no appointment types are found.</response>
        /// <response code="500">If there is a server error.</response>
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

        /// <summary>
        /// Get an appointment type by ID
        /// </summary>
        /// <param name="id">The ID of the appointment type to retrieve</param>
        /// <returns>The appointment type with the specified ID.</returns>
        /// <response code="200">Returns the appointment type found.</response>
        /// <response code="404">If the appointment type is not found.</response>
        /// <response code="500">If there is a server error.</response>
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

        /// <summary>
        /// Get appointment types by keyword
        /// </summary>
        /// <param name="keyword">The keyword to search appointment types by</param>
        /// <returns>A list of appointment types that match the keyword.</returns>
        /// <response code="200">Returns the list of appointment types matching the keyword.</response>
        /// <response code="400">If the keyword is not provided or is invalid.</response>
        /// <response code="404">If no appointment types are found with the provided keyword.</response>
        /// <response code="500">If there is a server error.</response>
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