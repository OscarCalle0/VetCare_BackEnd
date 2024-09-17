using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
                Console.WriteLine("The session storage is null");
                return " ";
            }
            
            // Access to JWT token
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            
            if (token == null)
            {
                Console.WriteLine("The token is null");

                return " ";
            }

            // Decode the token and extract the id
            var jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var userId = jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                Console.WriteLine("The claim 'nameid' is empty");
                return " ";
            }
            
            return userId;
        }
    }
}