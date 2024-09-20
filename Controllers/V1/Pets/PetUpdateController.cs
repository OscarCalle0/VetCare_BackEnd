using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Controllers.V1.Pets
{
    public partial class PetController
    {
        [HttpPut("UpdatePet/{id}")]
        public async Task<IActionResult> UpdatePet([FromForm]PetDTO _petDTO, int id)
        {
            if (_petDTO == null)
            {
                return BadRequest("Pet data is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var petToConvert = await _context.Pets.FindAsync(id);

            if (petToConvert == null)
            {
                return NotFound("Pet not found");
            }

            petToConvert.Name = _petDTO.Name.ToLower();

            petToConvert.Breed = _petDTO.Breed.ToLower();

            petToConvert.Weight = _petDTO.Weight.ToUpper();


            if (_petDTO.BirthDate.Year > DateTime.Now.Year)
            {
                return BadRequest("We have not yet reached the target date");
            }

            petToConvert.BirthDate = _petDTO.BirthDate;

            petToConvert.Sex = _petDTO.Sex.ToLower();

            if (petToConvert.ImagePath == null)
            {
                return BadRequest("No data in the storage");
            }
            if (petToConvert.DeleteHash == null)
            {
                return BadRequest("No data in the 'deleteHash' field");
            }
            if (_petDTO.Image == null)
            {
                return BadRequest("No data in the image field");
            }

            var deleteHash = petToConvert.DeleteHash;

            await _imageHelper.DeleteImage(deleteHash);

            var jsonResponse = await _imageHelper.PostImage(_petDTO.Image);

            petToConvert.ImagePath = jsonResponse["data"]["link"].ToString();
            petToConvert.DeleteHash = jsonResponse["data"]["deletehash"].ToString();

            await _context.SaveChangesAsync();
            return Ok("Pet Updated successfully");


        }
    }
}