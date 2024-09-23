using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace VetCare_BackEnd.Services
{
    public class ImageHelper
    {
        private readonly string _removeBgApiKey;

        public ImageHelper()
        {
            _removeBgApiKey = Environment.GetEnvironmentVariable("APIKEY_REMOVEBG");

            if (string.IsNullOrEmpty(_removeBgApiKey))
            {
                throw new InvalidOperationException("The Remove.bg API key is not configured. Please check your .env file.");
            }
        }

        // Method to remove the background from an image using the remove.bg API
        public async Task<byte[]> RemoveBackground(IFormFile file)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.remove.bg/v1.0/removebg");

            var content = new MultipartFormDataContent
            {
                { new StreamContent(file.OpenReadStream()), "image_file", file.FileName },
                { new StringContent("auto"), "size" }  // Adjust the image size if needed
            };

            request.Content = content;
            request.Headers.Add("X-Api-Key", _removeBgApiKey);

            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Error removing the background: " + await response.Content.ReadAsStringAsync());
                return null;
            }

            var result = await response.Content.ReadAsByteArrayAsync();
            return result;  // Returns the image without a background
        }

        // Method to upload an image to Imgur
        public async Task<JObject> PostImage(IFormFile file)
        {
            // Step 1: Remove the background from the image
            var imageWithoutBg = await RemoveBackground(file);
            if (imageWithoutBg == null)
            {
                Console.WriteLine("Error removing the background.");
                return null;
            }

            // Step 2: Upload the image without a background to Imgur
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.imgur.com/3/image");

            request.Headers.Add("Authorization", "Client-ID 3b079e41f999b5b");

            var content = new MultipartFormDataContent
            {
                { new ByteArrayContent(imageWithoutBg), "image", file.FileName },  // Upload the processed image without a background
                { new StringContent("image"), "type" },
                { new StringContent("Image of pet"), "title" },
                { new StringContent("This is pet image upload in Imgur"), "description" }
            };

            request.Content = content;

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);

            var jsonResponse = JObject.Parse(responseContent);

            if (jsonResponse == null)
            {
                Console.WriteLine("No content found in the JSON response.");
                return null;
            }

            return jsonResponse;
        }

        // Method to delete an image from Imgur using the deleteHash
        public async Task<bool> DeleteImage(string deleteHash)
        {
            if (string.IsNullOrEmpty(deleteHash))
            {
                Console.WriteLine("The deleteHash is empty.");
                return false;
            }

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, $"https://api.imgur.com/3/image/{deleteHash}");
            request.Headers.Add("Authorization", "Client-ID 3b079e41f999b5b");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            Console.WriteLine(await response.Content.ReadAsStringAsync());

            return true;
        }
    }
}
