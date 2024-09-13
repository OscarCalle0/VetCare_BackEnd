using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using VetCare_BackEnd.Models;
using VetCare_BackEnd.Data;
using Microsoft.IdentityModel.Tokens;
using VetCare_BackEnd.Services;

namespace VetCare_BackEnd.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtService _jwtService;
        private readonly IEmailService _emailService;

        public AuthService(ApplicationDbContext context, JwtService jwtService, IEmailService emailService)
        {
            _context = context;
            _jwtService = jwtService;
            _emailService = emailService;
        }

        // Encrypts the password using bcrypt before storing it in the database.
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Verifies if the plaintext password matches the encrypted one.
        public bool VerifyPassword(string plainPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }

        // Registers a user with the encrypted password.
        public void Register(User user, string plainPassword)
        {
            user.Password = HashPassword(plainPassword);
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // Generates a JWT token for login with an expiration of 1 hour.
        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtService._secretKey); // Uses the secret key from JwtService

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Token valid for 1 hour
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        // Generates a temporary JWT token for password reset with an expiration of 5 minutes.
        public string GeneratePasswordResetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtService._secretKey);  // Uses the secret key from JwtService

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5), // Token valid for 5 minutes
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        // Sends the password reset email with the generated token
        public void SendResetPasswordEmail(User user)
        {
            var token = GeneratePasswordResetToken(user);
            var resetLink = $"token={token}"; // domain
            _emailService.SendPasswordResetEmail(user.Email, resetLink);
        }

        // Verifies if the password reset token is valid
        public bool VerifyResetToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtService._secretKey);  // Uses the secret key from JwtService

            try
            {
                var claims = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero // No time tolerance
                }, out SecurityToken validatedToken);

                // The token is valid, so return true
                return true;
            }
            catch
            {
                // The token is invalid
                return false;
            }
        }

        // Resets the user's password if the token is valid
        public bool ResetPassword(string token, string newPassword)
        {
            if (!VerifyResetToken(token)) return false; // Invalid token

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            if (jwtToken == null) return false;

            var userId = jwtToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;

            // Finds the user by ID
            var user = _context.Users.SingleOrDefault(u => u.Id == int.Parse(userId));
            if (user == null) return false; // User not found

            // Updates the user's password
            user.Password = HashPassword(newPassword);
            _context.SaveChanges();

            return true; // Password reset successful
        }
    }
}
