using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.CRUD;
using VetCare_BackEnd.Data;

namespace VetCare_BackEnd.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserDeleteController : ControllerBase
    {
        private readonly ApplicationDbContext ConnectionDb;

        public UserDeleteController(ApplicationDbContext variableConnection)
        {
            ConnectionDb= variableConnection;
        }

        [HttpDelete]

        public async Task<ActionResult> DeletingById (int id)
        {
            var Usersearch = await ConnectionDb.Users.FindAsync(id);
            ConnectionDb.Users.Remove(Usersearch);
            ConnectionDb.SaveChanges();
            return NoContent();
        }



    }
}