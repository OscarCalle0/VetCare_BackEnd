using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetCare_BackEnd.Services.Interfaces;
using VetCare_BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using VetCare_BackEnd.Models; 


namespace VetCare_BackEnd.Services
{
    public class PetService : IPetService
    {
        private readonly ApplicationDbContext _context;

        public PetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Pet> GetPetByIdAsync(int petId)
        {
            return await _context.Pets.FindAsync(petId);
        }

        public async Task<List<Pet>> GetAllPetsAsync()
        {
            return await _context.Pets.ToListAsync();
        }
    }
}