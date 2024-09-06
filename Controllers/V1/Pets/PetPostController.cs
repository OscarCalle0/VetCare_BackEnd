using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetCare_BackEnd.Data;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Controllers.V1.Pets
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetPostController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PetPostController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("CreatePet")]
        public async Task<IActionResult> CreatePet([FromBody] PetDTO _petDTO)
        {
            if (_petDTO == null)
            {
                return BadRequest("Pet data is null");
            }

            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == _petDTO.user_id);

            if (user == null)
            {
                return NotFound("An user by that Id doesnt exist");
            }

            if (_petDTO.BirthDate.Year > DateTime.Now.Year)
            {
                return BadRequest("We have not yet reached the target date");
            }

            var pet = new Pet
            {
                Name = _petDTO.Name.ToLower(),
                Breed = _petDTO.Breed.ToLower(),
                Weight = _petDTO.Weight.ToUpper(),
                BirthDate = _petDTO.BirthDate,
                Sex = _petDTO.Sex.ToLower(),
                user_id = _petDTO.user_id,
                User = user
            };

            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return Created();
        }
    }
}