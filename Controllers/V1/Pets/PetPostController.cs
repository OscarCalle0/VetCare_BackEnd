using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VetCare_BackEnd.Data;
using VetCare_BackEnd.Models;
using VetCare_BackEnd.Services;

namespace VetCare_BackEnd.Controllers.V1.Pets
{
    public partial class PetController : ControllerBase
    {
        [HttpPost("CreatePet")]
        public async Task<IActionResult> CreatePet([FromForm] PetDTO _petDTO)
        {
            if (_petDTO == null)
            {
                return BadRequest("Pet data is null");
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (_petDTO.BirthDate.Year > DateTime.Now.Year)
            {
                return BadRequest("We have not yet reached the target date");
            }

            int userId;
            var userIdClaim = _jwtHelper.GetIdFromJWT();

            if (string.IsNullOrWhiteSpace(userIdClaim) || !int.TryParse(userIdClaim, out userId))
            {
                return NotFound("Unable to retrieve user ID from token");
            }

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            if (_petDTO.Image == null)
            {
                return BadRequest("The Image field doesn't have data");
            }

            var imagePath = _imageHelper.CreateImage(_petDTO.Image);
            if (string.IsNullOrEmpty(imagePath))
            {
                return BadRequest("The image cannot be saved");
            }

            var pet = new Pet
            {
                Name = _petDTO.Name.ToLower(),
                Breed = _petDTO.Breed.ToLower(),
                Weight = _petDTO.Weight,
                BirthDate = _petDTO.BirthDate,
                Sex = _petDTO.Sex.ToLower(),
                user_id = userId,
                ImagePath = imagePath,
                User = user
            };

            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            // Return 201 Created with the pet ID and a success message
            return CreatedAtAction(nameof(CreatePet), new { id = pet.Id }, new 
            {
                message = "Pet created successfully",
                petId = pet.Id
            });
        }
    }
}
