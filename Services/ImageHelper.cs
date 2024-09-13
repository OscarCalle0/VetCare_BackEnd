using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VetCare_BackEnd.Services
{
    public class ImageHelper
    {
        private readonly IWebHostEnvironment _environment;

        public ImageHelper(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<bool> DeleteImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                Console.WriteLine("The Path is empty");
                return false;
            }


            if (!imagePath.StartsWith("/images/"))
            {
                Console.WriteLine("The path does not start with /images/");
                return false;
            }

            string fullPath = Path.Combine(_environment.WebRootPath, imagePath.TrimStart('/'));

            try
            {
                if (!File.Exists(fullPath))
                {
                    Console.WriteLine("The file does not exist");
                    return false;
                }

                await Task.Run(() => File.Delete(fullPath));
                return true;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error deleting the image: {ex.Message}");
                return false;
            }
        }

        public async Task<string> CreateImageAsync(IFormFile file)
        {
            // Ensure the directory exists
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            // Generate a unique filename
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadPath, fileName);

            // Save the file
            try
            {

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return $"/images/{fileName}";

            }
            catch
            {
                return string.Empty;
            }

        }

        public string CreateImage(IFormFile file)
        {
            return CreateImageAsync(file).GetAwaiter().GetResult();
        }
    }
}