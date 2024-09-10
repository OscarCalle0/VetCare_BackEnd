using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetCare_BackEnd.Data;

namespace VetCare_BackEnd.Controllers.V1.Pets
{
    
    public partial class PetController
    {
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
        public async Task<IActionResult> PetById([FromRoute] int id)
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