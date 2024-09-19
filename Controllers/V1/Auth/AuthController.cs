using Microsoft.AspNetCore.Mvc;
using VetCare_BackEnd.Models;
using VetCare_BackEnd.Models.Dtos;
using VetCare_BackEnd.Services;
using VetCare_BackEnd.Data;

namespace VetCare_BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly ApplicationDbContext _context;
        private readonly JwtService _jwtService;
        private readonly IEmailService _emailService;

        public AuthController(AuthService authService, ApplicationDbContext context, JwtService jwtService, IEmailService emailService)
        {
            _authService = authService;
            _context = context;
            _jwtService = jwtService;
            _emailService = emailService;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="registerDto">User registration data.</param>
        /// <returns>Result of the operation, including success or error message.</returns>
        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDto registerDto)
        {
            if (_context.Users.Any(u => u.Email == registerDto.Email))
            {
                return BadRequest("User already exists.");
            }

            // Encrypt the password
            var hashedPassword = _authService.HashPassword(registerDto.Password);

            var user = new User
            {
                Name = registerDto.Name,
                LastName = registerDto.LastName,
                BirthDate = registerDto.BirthDate,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                DocumentNumber = registerDto.DocumentNumber,
                DocumentTypeId = registerDto.DocumentTypeId,
                Password = hashedPassword, // Encrypted password
                RoleId = registerDto.RoleId
            };

            _authService.Register(user, registerDto.Password);
            return Ok("User successfully registered.");
        }

        /// <summary>
        /// Logs in and generates a JWT token.
        /// </summary>
        /// <param name="loginDto">User login data.</param>
        /// <returns>JWT token and user data on success, or error message on failure.</returns>
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == loginDto.Email);
            if (user == null || !_authService.VerifyPassword(loginDto.Password, user.Password))
                return Unauthorized("Incorrect email or password.");

            // Retrieve the user's role ID
            var roleId = user.RoleId; 

            // Generate JWT token
            var token = _jwtService.GenerateJwtToken(user, roleId);

            // Response structure
            var response = new
            {
                token = token, // Generated token
                expiration = DateTime.UtcNow.AddHours(1).ToString("yyyy-MM-ddTHH:mm:ssZ"), // Expiration in 1 hour
                data = new
                {
                    id = user.Id, // User ID
                    username = user.Name, // Username
                    lastname = user.LastName,
                    email = user.Email, // User email
                    roleId = user.RoleId // User role ID
                }
            };
            return Ok(response);
        }

        /// <summary>
        /// Requests a password reset by sending a link via email.
        /// </summary>
        /// <param name="request">Password reset request containing the user's email.</param>
        /// <returns>Success or error message based on the operation result.</returns>
        [HttpPost("RequestPasswordReset")]
        public IActionResult RequestPasswordReset([FromBody] ResetPasswordRequest request)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == request.Email);
            if (user == null) return NotFound("User not found.");

            var token = _authService.GeneratePasswordResetToken(user); // Generate password reset token
            var expiration = DateTime.UtcNow.AddMinutes(5); // Expiration in 5 minutes

            var resetLink = Url.Action("ResetPassword", "Auth", new { token = token }, Request.Scheme);

            _emailService.SendPasswordResetEmail(user.Email, resetLink);

            // Response format
            var response = new
            {
                token = token, // Generated token
                expiration = expiration, // Token expiration date
                data = new
                {
                    id = user.Id, // User ID
                    username = user.Name, // User name
                    email = user.Email // User email
                },
                message = "A password reset link has been sent to your email." 
            };

            return Ok(response);
        }

        /// <summary>
        /// Resets the user's password using a reset token.
        /// </summary>
        /// <param name="resetPasswordDto">Data required to reset the password, including the token and new password.</param>
        /// <returns>Success or error message based on the operation result.</returns>
        [HttpPost("ResetPassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            // Token sent by the user from the frontend
            var storedToken = resetPasswordDto.Token;

            // Verify the token
            if (!_authService.VerifyResetToken(storedToken))
                return Unauthorized("Invalid or expired token.");

            var user = _context.Users.SingleOrDefault(u => u.Email == resetPasswordDto.Email);
            if (user == null) return NotFound("User not found.");

            // If the token is valid, update the password
            user.Password = _authService.HashPassword(resetPasswordDto.NewPassword);
            _context.SaveChanges();

            // Send notification email about password change
            _emailService.SendPasswordChangedEmail(user.Email);

            return Ok("Password has been successfully reset.");
        }
    }
}
