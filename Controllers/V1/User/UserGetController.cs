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
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserGetController : ControllerBase
    {
        private readonly ApplicationDbContext ConnectionDb;

        public UserGetController(ApplicationDbContext variableConnection)
        {
            ConnectionDb = variableConnection;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await ConnectionDb.Users.ToListAsync();
        }

        //GET /Users/ id/{id}

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var Usersearch = await ConnectionDb.Users.FindAsync(id);
            return Ok(Usersearch);
        }

        [HttpGet("findByName/{name}")]

        public async Task<ActionResult<IEnumerable<User>>> GetUserByname(string name)
        {
            var Usersearch = await ConnectionDb.Users.FirstOrDefaultAsync(p => p.Name.Contains(name));
            if (Usersearch == null)
            {
                return NotFound("This name is not in our sistem"); // Return 404 if the user is not found
            }
            return Ok(Usersearch);
        }

        [HttpGet ("FindByInitial/{initial}")]

        public async Task<ActionResult> GetUserByLetter (string initial)
        {
            var Usersearch = await ConnectionDb.Users.Where(p =>p.Name.StartsWith(initial)).ToListAsync();
            if (Usersearch == null)
            {
                return NotFound("There is Not a name that start with that letter");
            }
            return Ok(Usersearch);
        }

        

    }


}