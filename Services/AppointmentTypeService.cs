using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VetCare_BackEnd.Data;
using VetCare_BackEnd.Models;
using VetCare_BackEnd.Services.Interfaces;

namespace VetCare_BackEnd.Services
{
   public class AppointmentTypeService : IAppointmentTypeService
    {
        private readonly ApplicationDbContext _context;

        public AppointmentTypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AppointmentType> GetAppointmentTypeByIdAsync(int id)
        {
            return await _context.AppointmentTypes.FindAsync(id);
        }
    }
}