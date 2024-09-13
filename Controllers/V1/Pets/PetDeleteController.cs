using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mysqlx;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Controllers.V1.Pets
{
    public partial class PetController
    {
        [HttpDelete("DeletePet/{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var result = await _context.Pets.FindAsync(id);

            if (result == null)
            {
                return NotFound("Data Not Found");
            }

            var filePath = result.ImagePath;

            if (filePath != null)
            {
                bool ImageDeleted = await _imageHelper.DeleteImage(filePath);

                if (!ImageDeleted)
                {
                    Console.WriteLine("The image cannot be removed from the directory");
                }

            }

            

            _context.Pets.Remove(result);
            await _context.SaveChangesAsync();

            return Ok("Pet removed successfully");
        }
    }
}