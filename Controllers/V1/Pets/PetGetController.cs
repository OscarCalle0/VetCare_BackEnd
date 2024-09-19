using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace VetCare_BackEnd.Controllers.V1.Pets
{
    
    public partial class PetController
    {
        /// <summary>
        /// Show the pets paginated
        /// </summary>
        ///<param name="page">The param for the number of page</param>
        ///<param name="quantity">The param for the number pets in the page</param>
        ///<returns>The quantity of pets that you request by page</returns>
        [HttpGet("allPaginatedPets")]
        public async Task<IActionResult> AllPets([FromQuery] int page, [FromQuery] int quantity)
        {
            if (page < 1)
            {
                return BadRequest("the page number must be greated than or equal to 1");
            }
            if (quantity < 1)
            {
                return BadRequest("the page size must be greated than or equal to 1.");
            }

            var result = await _context.Pets
            .Skip((page - 1)*quantity)
            .Take(quantity)
            .ToListAsync();

            if (result.Count == 0)
            {
                return NotFound("The table 'Pets' is empty");
            }

            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

        [HttpGet("petByUserId/{id}")]
        public async Task<IActionResult> PetByUserId([FromRoute]int id)
        {
            var result = await _context.Pets.Where(p => p.user_id == id).ToListAsync();

            if (result == null)
            {
                return NotFound("Id Not Found");
            }

            return Ok(result);
        }
    }
}