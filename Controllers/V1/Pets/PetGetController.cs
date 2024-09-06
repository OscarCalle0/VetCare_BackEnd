using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetCare_BackEnd.Data;

namespace VetCare_BackEnd.Controllers.V1.Pets
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetGetController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PetGetController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("allPets")]
        public async Task<IActionResult> AllPets()
        {
            var result = await _context.Pets.ToListAsync();

            if (result.Count == 0)
            {
                return NotFound("The table 'Pets' is empty");
            }

            return Ok(result);
        }

        [HttpGet("petById/{id}")]
        public async Task<IActionResult> PetById(int id)
        {
            var result = await _context.Pets.FirstOrDefaultAsync(p => p.Id == id);

            if (result == null)
            {
                return NotFound("Id Not Found");
            }

            return Ok(result);
        }
    }
}