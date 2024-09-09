using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetCare_BackEnd.Data;

namespace VetCare_BackEnd.Controllers.V1.DocumentTypes
{
    [ApiController]
    [Route("api/v1/DocumentTypes")]
    public class DocumentTypesGetController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DocumentTypesGetController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("AllDocumentTypes")]
        public async Task<IActionResult> GetAll()
        {
            var result = _context.DocumentTypes.ToListAsync();

            return Ok(result);
        }
    }
}