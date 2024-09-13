using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Controllers.V1.AppointmentTypes;
public partial class AppointmentTypesController
{
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