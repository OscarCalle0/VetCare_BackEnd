using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VetCare_BackEnd.Models;
using VetCare_BackEnd.Data;
using VetCare_BackEnd.Models.Dtos;
using VetCare_BackEnd.Services;

namespace VetCare_BackEnd.Controllers.V1
{
    public partial class UserController
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthService _authService;

        public UserController(ApplicationDbContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="id">The id of the user that is going to be updated.</param>
        /// <param name="updateUserDto">User update data.</param>
        /// <returns>A success message for the update of the user.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserDto updateUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userToUpdate = await _context.Users.FindAsync(id);

            if (userToUpdate == null)
            {
                return NotFound("User was not found.");
            }

            // Update only the fields that are not null
            userToUpdate.Name = string.IsNullOrWhiteSpace(updateUserDto.Name) ? userToUpdate.Name : updateUserDto.Name;
            userToUpdate.LastName = string.IsNullOrWhiteSpace(updateUserDto.LastName) ? userToUpdate.LastName : updateUserDto.LastName;
            userToUpdate.BirthDate = updateUserDto.BirthDate == default ? userToUpdate.BirthDate : updateUserDto.BirthDate; // Ensure BirthDate is Nullable if needed
            userToUpdate.DocumentNumber = string.IsNullOrWhiteSpace(updateUserDto.DocumentNumber) ? userToUpdate.DocumentNumber : updateUserDto.DocumentNumber;

            // If the password is provided, hash it
            if (!string.IsNullOrWhiteSpace(updateUserDto.Password))
            {
                userToUpdate.Password = _authService.HashPassword(updateUserDto.Password);
            }

            userToUpdate.PhoneNumber = string.IsNullOrWhiteSpace(updateUserDto.PhoneNumber) ? userToUpdate.PhoneNumber : updateUserDto.PhoneNumber;
            userToUpdate.Email = string.IsNullOrWhiteSpace(updateUserDto.Email) ? userToUpdate.Email : updateUserDto.Email;
            userToUpdate.DocumentTypeId = updateUserDto.DocumentTypeId != 0 ? updateUserDto.DocumentTypeId : userToUpdate.DocumentTypeId; // Ensure DocumentTypeId has a valid default value
            userToUpdate.RoleId = updateUserDto.RoleId != 0 ? updateUserDto.RoleId : userToUpdate.RoleId; // Ensure RoleId has a valid default value

            await _context.SaveChangesAsync(); // Save changes to the context
            return Ok("The user has been updated successfully.");
        }
    }
}
