using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetCare_BackEnd.Data;

namespace VetCare_BackEnd.Controllers.V1.DocumentTypes
{

    public partial class DocumentTypeController
    {

        /// <summary>
        ///  Show all the Document types
        /// </summary>
        /// <returns>shows all document types.</returns>
        [HttpGet]
        
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.DocumentTypes.ToListAsync();

            return Ok(result);
        }
    }
}