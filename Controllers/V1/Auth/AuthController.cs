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
        /// <response code="200">User successfully registered.</response>
        /// <response code="400">User already exists.</response>
        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDto registerDto)
        {
            if (_context.Users.Any(u => u.Email == registerDto.Email))
            {
                return BadRequest("User already exists.");
            }

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
                Password = hashedPassword,
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
        /// <response code="200">Successfully logged in, returns the token and user data.</response>
        /// <response code="401">Incorrect email or password.</response>
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == loginDto.Email);
            if (user == null || !_authService.VerifyPassword(loginDto.Password, user.Password))
                return Unauthorized("Incorrect email or password.");

            var roleId = user.RoleId; 
            var token = _jwtService.GenerateJwtToken(user, roleId);

            var response = new
            {
                token = token,
                expiration = DateTime.UtcNow.AddMinutes(30).ToString("yyyy-MM-ddTHH:mm:ssZ"),
                data = new
                {
                    id = user.Id,
                    username = user.Name,
                    lastname = user.LastName,
                    email = user.Email,
                    roleId = user.RoleId
                }
            };
            return Ok(response);
        }

        /// <summary>
        /// Requests a password reset by sending a link via email.
        /// </summary>
        /// <param name="request">Password reset request containing the user's email.</param>
        /// <returns>Success or error message based on the operation result.</returns>
        /// <response code="200">A password reset link has been sent to your email.</response>
        /// <response code="404">User not found.</response>
        [HttpPost("RequestPasswordReset")]
        public IActionResult RequestPasswordReset([FromBody] ResetPasswordRequest request)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == request.Email);
            if (user == null) return NotFound("User not found.");

            var token = _authService.GeneratePasswordResetToken(user);
            var expiration = DateTime.UtcNow.AddMinutes(5);
            var resetLink = Url.Action("ResetPassword", "Auth", new { token = token }, Request.Scheme);

            _emailService.SendPasswordResetEmail(user.Email, resetLink);

            var response = new
            {
                token = token,
                expiration = expiration,
                data = new
                {
                    id = user.Id,
                    username = user.Name,
                    email = user.Email
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
        /// <response code="200">Password has been successfully reset.</response>
        /// <response code="401">Invalid or expired token.</response>
        /// <response code="404">User not found.</response>
        [HttpPost("ResetPassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            var storedToken = resetPasswordDto.Token;

            if (!_authService.VerifyResetToken(storedToken))
                return Unauthorized("Invalid or expired token.");

            var user = _context.Users.SingleOrDefault(u => u.Email == resetPasswordDto.Email);
            if (user == null) return NotFound("User not found.");

            user.Password = _authService.HashPassword(resetPasswordDto.NewPassword);
            _context.SaveChanges();

            _emailService.SendPasswordChangedEmail(user.Email);

            return Ok("Password has been successfully reset.");
        }
    }
}
