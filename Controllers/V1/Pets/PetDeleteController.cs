using Microsoft.AspNetCore.Mvc;


namespace VetCare_BackEnd.Controllers.V1.Pets
{
    public partial class PetController
    {
        /// <summary>
        /// To Delete the pet
        /// </summary>
        /// <param name="id">Insert the id of the pet to delete</param>
        /// <returns>Status codes</returns>
        [HttpDelete("DeletePet/{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var result = await _context.Pets.FindAsync(id);

            if (result == null)
            {
                return NotFound("Data Not Found");
            }

            var deleteHash = result.DeleteHash;

            if (deleteHash != null)
            {
                bool ImageDeleted = await _imageHelper.DeleteImage(deleteHash);

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