using Newtonsoft.Json.Linq;

namespace VetCare_BackEnd.Services
{
    public class ImageHelper
    {
        public ImageHelper()
        {
        }

        public async Task<bool> DeleteImage(string deleteHash)
        {
            if (string.IsNullOrEmpty(deleteHash))
            {
                Console.WriteLine("The Path is empty");
                return false;
            }

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, $"https://api.imgur.com/3/image/{deleteHash}");
            request.Headers.Add("Authorization", $"Client-ID 3b079e41f999b5b");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            Console.WriteLine(await response.Content.ReadAsStringAsync());

            return true;
        }

        
        public async Task<JObject> PostImage(IFormFile file)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.imgur.com/3/image");

            request.Headers.Add("Authorization", "Client-ID 3b079e41f999b5b");

            var content = new MultipartFormDataContent
            {
                { new StreamContent(file.OpenReadStream()), "image", file.FileName },
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
                Console.WriteLine("No content in the json response ");
                return null;
            }

            return jsonResponse;

        }
    }
}