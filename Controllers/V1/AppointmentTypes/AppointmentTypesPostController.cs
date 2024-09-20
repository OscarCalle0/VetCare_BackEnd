using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Controllers.V1.AppointmentTypes;
public partial class AppointmentTypesController
{
    
    /// <summary>
    /// Create a new appointment type
    /// </summary>
    /// <param name="newAppointmentType">The appointment type object to be created</param>
    /// <returns>A response indicating the result of the appointment type creation.</returns>
    /// <response code="200">Returns a message indicating the appointment type was successfully created.</response>
    /// <response code="400">If the input data is invalid.</response>
    /// <response code="500">If there is a server error.</response>
    [HttpPost("create")]
    public async Task<IActionResult> Create(AppointmentType newAppointmentType)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _context.AppointmentTypes.AddAsync(newAppointmentType);
        await _context.SaveChangesAsync();
        return Ok("Appointment Added successfully");
    }
}