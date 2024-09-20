using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VetCare_BackEnd.Data;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Controllers.V1
{

    public partial class UserController
    {

        /// <summary>
        /// Retrieves a paginated list of users.
        /// </summary>
        /// <param name="pageNumber">The page number to retrieve.</param>
        /// <param name="pageSize">The number of users per page.</param>
        /// <returns>A paginated list of users.</returns>


        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10

        )


        {
            if (pageNumber < 1)
            {
                return BadRequest("The number page must be equal or greater than 1");
            }

            if (pageSize < 1)
            {
                return BadRequest("The page Size  must be equal or greater than 1");
            }
            var Users = await _userService.Users
             .Skip((pageNumber - 1) * pageSize)
             .Take(pageSize)
             .ToListAsync();
            return Ok(Users);
        }

        /// <summary>
        /// FindS a user by id
        /// </summary>
        /// <param name="id">The id of user you want to find.</param>
        /// <returns>The information of the user that has been search, </returns>

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var Usersearch = await _userService.Users.FindAsync(id);

            // Verifica si el usuario existe
            if (Usersearch == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return Ok(Usersearch);
        }



        /// <summary>
        /// Finds a user by name
        /// </summary>
        /// <param name="name">The name of user you want to find.</param>
        /// <returns>The informarion of the user that has been search, </returns>
        /// 
        [HttpGet("findByName/{name}")]

        public async Task<ActionResult<IEnumerable<User>>> GetUserByname([FromRoute] string name)
        {
            var Usersearch = await _userService.Users.FirstOrDefaultAsync(p => p.Name.Contains(name));
            if (Usersearch == null)
            {
                return NotFound("This name is not in our sistem"); // Return 404 if the user is not found
            }
            return Ok(Usersearch);
        }

        /// <summary>
        /// Finds a user by initial
        /// </summary>
        /// <param name="initial">The initial letter of user you want to find.</param>
        /// <returns>The information of the user that has been search, </returns>

        [HttpGet("FindByInitial/{initial}")]


        public async Task<ActionResult> GetUserByLetter(string initial)
        {
            var Usersearch = await _userService.Users.Where(p => p.Name.StartsWith(initial)).ToListAsync();
            if (Usersearch == null)
            {
                return NotFound("There is Not a name that start with that letter");
            }
            return Ok(Usersearch);
        }

        /// <summary>
        /// Finds a user by keywords.
        /// </summary>
        /// <param name="keyword">The keyword used to search for the user.</param>
        /// <returns>The information of the found user.</returns>


        [HttpGet("getbykeyword")]
        public async Task<IActionResult> GetByKeyword([FromQuery] string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return BadRequest("Keyword is required");
            }

            var users = await _userService.Users.ToListAsync();

            var result = users.Where(r =>
                r.Name.Contains(keyword, System.StringComparison.OrdinalIgnoreCase)).
            ToList();

            if (result.Count() == 0)
            {
                return NotFound("No roles found with that keyword");
            }
            return Ok(result);
        }

    }

}


