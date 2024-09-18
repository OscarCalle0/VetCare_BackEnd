using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace VetCare_BackEnd.Services
{
    public class JwtHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetIdFromJWT()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
            {
                Console.WriteLine("The HTTP context is null.");
                return string.Empty;
            }

            // Access the JWT token from the Authorization header
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrWhiteSpace(token))
            {
                Console.WriteLine("The token is null or empty.");
                return string.Empty;
            }

            Console.WriteLine($"Received token: {token}"); // Log to verify the token

            try
            {
                // Decode the token and extract the ID from the "Id" claim
                var jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
                var userId = jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;

                // Log all claims for debugging
                foreach (var claim in jwtSecurityToken.Claims)
                {
                    Console.WriteLine($"Claim type: {claim.Type}, Claim value: {claim.Value}");
                }

                if (string.IsNullOrEmpty(userId))
                {
                    Console.WriteLine("The 'Id' claim is empty.");
                    return string.Empty;
                }

                Console.WriteLine($"User ID extracted from token: {userId}"); // Log the extracted ID

                return userId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading the token: {ex.Message}");
                return string.Empty;
            }
        }
    }
}
