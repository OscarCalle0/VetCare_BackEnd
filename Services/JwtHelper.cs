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
                Console.WriteLine("El contexto HTTP es nulo.");
                return string.Empty;
            }

            // Acceder al token JWT del encabezado Authorization
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrWhiteSpace(token))
            {
                Console.WriteLine("El token es nulo o vacío.");
                return string.Empty;
            }

            Console.WriteLine($"Token recibido: {token}"); // Log para verificar el token

            try
            {
                // Decodificar el token y extraer el ID del reclamo "Id"
                var jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
                var userId = jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;

                // Loggear todos los reclamos para depuración
                foreach (var claim in jwtSecurityToken.Claims)
                {
                    Console.WriteLine($"Tipo de reclamo: {claim.Type}, Valor del reclamo: {claim.Value}");
                }

                if (string.IsNullOrEmpty(userId))
                {
                    Console.WriteLine("El reclamo 'Id' está vacío.");
                    return string.Empty;
                }

                Console.WriteLine($"ID de usuario extraído del token: {userId}"); // Log del ID extraído

                return userId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el token: {ex.Message}");
                return string.Empty;
            }
        }
    }
}
