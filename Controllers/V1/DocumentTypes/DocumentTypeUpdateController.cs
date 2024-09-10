using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetCare_BackEnd.Data;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Controllers.V1.DocumentTypes
{

    public partial class DocumentTypeController
    {

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, string newDocumentTypeName)
        {
            if (string.IsNullOrEmpty(newDocumentTypeName))
            {
                return BadRequest("Document Type can't be empty");
            }

            var DocumentToUpdate = await _context.DocumentTypes.FindAsync(id);

            if (DocumentToUpdate == null)
            {
                return NotFound("it was not found");
            }

            DocumentToUpdate.Name = newDocumentTypeName;
            await _context.SaveChangesAsync();
            return Ok("The Document Type Name has been updated successfully");

        }
    }
}