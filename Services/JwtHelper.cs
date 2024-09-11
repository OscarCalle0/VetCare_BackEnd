using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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

        public async Task<string> GetIdFromJWT()
        {

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                // Acceder al JWT token desde el encabezado de autorización
                var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                if (token != null)
                {
                    // Decodificar el token y extraer la información que necesitas
                    var jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
                    var userId = jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
                    return userId;
                }
            }

            return null;



            // var token = await Task.FromResult(_httpContextAccessor.HttpContext.Session.GetString("jwt"));

            // if (string.IsNullOrEmpty(token))
            // {
            //     Console.WriteLine("Token not found");
            //     return null;
            // }

            // var handler = new JwtSecurityTokenHandler();
            // var jsonToken = await Task.Run(() => handler.ReadToken(token) as JwtSecurityToken);

            // if (jsonToken == null)
            // {
            //     Console.WriteLine("The token is not a valid JWT");
            //     return null;
            // }

            // var userIdClaim = await Task.Run(() => jsonToken.Claims.FirstOrDefault(claim => claim.Type == "id"));

            // if (userIdClaim == null)
            // {
            //     Console.WriteLine("The token doesnt have the claim 'id'");
            //     return null;
            // }

            // return userIdClaim.Value;
        }
    }
}