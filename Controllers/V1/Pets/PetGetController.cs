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
        ///<response code="400">Not valid params</response>
        ///<response code="404">No Data in the database (it could be due the page number entered)</response>
        ///
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
        /// Show all the registered pets
        /// </summary>
        /// <returns>A Json with all registered pets</returns>
        /// <response code="400">No pets in the database</response>
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

        /// <summary>
        /// Search a pet by his id
        /// </summary>
        /// <param name="id">The id from the pet to search</param>
        /// <returns>A json of one pet</returns>
        /// <response code="404">No pet has been found with that id</response>
        /// <response code="400">Incorrect param </response>
        [HttpGet("petById/{id}")]
        public async Task<IActionResult> PetById([FromRoute] int id)
        {
            if (id < 0)
            {
                return BadRequest("The param 'id' need to be greater than 0");
            }
            var result = await _context.Pets.FirstOrDefaultAsync(p => p.Id == id);

            if (result == null)
            {
                return NotFound("Id Not Found");
            }

            return Ok(result);
        }

        /// <summary>
        /// Search a pet by the id of his owner
        /// </summary>
        /// <param name="id">The id from the user</param>
        /// <returns>A json of one pet</returns>
        /// <response code="404">No user has been found with that id or That user does not have pets</response>
        [HttpGet("petByUserId/{id}")]
        public async Task<IActionResult> PetByUserId([FromRoute]int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound("No user has been found with that id");
            }

            var result = await _context.Pets.Where(p => p.user_id == id).ToListAsync();

            if (result.Count == 0)
            {
                return NotFound("That user does not have pets");
            }

            return Ok(result);
        }
    }
}