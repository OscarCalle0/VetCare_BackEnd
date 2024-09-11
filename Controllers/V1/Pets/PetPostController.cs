using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VetCare_BackEnd.Data;
using VetCare_BackEnd.Models;
using VetCare_BackEnd.Services;

namespace VetCare_BackEnd.Controllers.V1.Pets
{
    public partial class PetController
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

            if (_petDTO.BirthDate.Year > DateTime.Now.Year)
            {
                return BadRequest("We have not yet reached the target date");
            }


            // ------- Verificar

            int userId;
            var userIdClaim = await _jwtHelper.GetIdFromJWT();

            if (userIdClaim == null || !int.TryParse(userIdClaim, out userId))
            {
                return NotFound("Unable to retrieve user ID from token");
            }
            // ----------------

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            if (_petDTO.Image == null)
            {
                return BadRequest("The Image field dont have data");
            }

            // Ensure the directory exists
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            // Generate a unique filename
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(_petDTO.Image.FileName);
            var filePath = Path.Combine(uploadPath, fileName);

            // Save the file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await _petDTO.Image.CopyToAsync(stream);
            }
    


            var pet = new Pet
            {
                Name = _petDTO.Name.ToLower(),
                Breed = _petDTO.Breed.ToLower(),
                Weight = _petDTO.Weight.ToUpper(),
                BirthDate = _petDTO.BirthDate,
                Sex = _petDTO.Sex.ToLower(),
                user_id = userId,
                ImagePath = $"/images/{fileName}",
                User = user
            };

            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return Created();
        }
    }
}