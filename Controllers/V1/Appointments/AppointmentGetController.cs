using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VetCare_BackEnd.Controllers.V1.Appointments;

public partial class AppointmentController
{
    /// <summary>
    /// Retrieves all appointments with pagination.
    /// </summary>
    /// <param name="pageNumber">The page number for pagination.</param>
    /// <param name="pageSize">The number of appointments per page.</param>
    /// <returns>A list of appointments.</returns>
    /// <response code="200">Returns a list of appointments.</response>
    /// <response code="400">If the page number or size is invalid.</response>
    [HttpGet("getall")]
    public async Task<IActionResult> Get(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        if (pageNumber < 1)
        {
            return BadRequest("The page number must be greater than or equal to 1.");
        }
        if (pageSize < 1)
        {
            return BadRequest("The page size must be greater than or equal to 1.");
        }

        var appointments = await _context.Appointments
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        if (appointments.Count < 1)
        {
            return BadRequest("No data found.");
        }

        return Ok(appointments);
    }

    /// <summary>
    /// Retrieves an appointment by its ID.
    /// </summary>
    /// <param name="id">The ID of the appointment to retrieve.</param>
    /// <returns>The appointment details.</returns>
    /// <response code="200">Returns the appointment details.</response>
    /// <response code="404">If the appointment with the specified ID is not found.</response>
    [HttpGet("getbyid/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);
        if (appointment == null)
        {
            return NotFound("Appointment not found.");
        }
        return Ok(appointment);
    }

    /// <summary>
    /// Retrieves appointments that match the specified keyword in their description.
    /// </summary>
    /// <param name="keyword">The keyword to search for in the appointment descriptions.</param>
    /// <returns>A list of appointments that match the keyword.</returns>
    /// <response code="200">Returns a list of matching appointments.</response>
    /// <response code="400">If the keyword is not provided.</response>
    /// <response code="404">If no appointments match the keyword.</response>
    [HttpGet("getbykeyword")]
    public async Task<IActionResult> GetByKeyword([FromQuery] string keyword)
    {
        if (string.IsNullOrEmpty(keyword))
        {
            return BadRequest("Keyword is required.");
        }

        var appointments = await _context.Appointments.ToListAsync();

        var result = appointments.Where(r =>
            !string.IsNullOrEmpty(r.Description) && r.Description.Contains(keyword, System.StringComparison.OrdinalIgnoreCase)).ToList();

        if (result.Count == 0)
        {
            return NotFound("No appointments found with that keyword.");
        }
        return Ok(result);
    }

    /// <summary>
    /// Retrieves appointments by the pet's ID.
    /// </summary>
    /// <param name="petId">The ID of the pet to retrieve appointments for.</param>
    /// <returns>A list of appointments for the specified pet.</returns>
    /// <response code="200">Returns a list of appointments for the specified pet.</response>
    /// <response code="404">If no appointments for the pet are found.</response>
    [HttpGet("getbypetid/{petId}")]
    public async Task<IActionResult> GetByPetId([FromRoute] int petId)
    {
        var appointments = await _context.Appointments
            .Where(a => a.PetId == petId)
            .ToListAsync();

        if (appointments == null || !appointments.Any())
        {
            return NotFound("No appointments found for the specified pet.");
        }

        return Ok(appointments);
    }

}
