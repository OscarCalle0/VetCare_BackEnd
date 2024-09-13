using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetCare_BackEnd.Data;

namespace VetCare_BackEnd.Controllers.V1.Role
{
    [ApiController]
    [Route("api/v1/roles")]
    public class RolesGetController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RolesGetController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("AllRoles")]
        public async Task<IActionResult> GetAll() {
            var AllRoles = await _context.Roles.ToListAsync();

            if(AllRoles.Count() >= 1){
                return Ok(AllRoles);
            }

            else{
                return NotFound("any value found");
            }
        }
    }
}