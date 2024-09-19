using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetCare_BackEnd.Models;
using VetCare_BackEnd.Services;
using VetCare_BackEnd.Data;
using VetCare_BackEnd.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


public class AppointmentService : IAppointmentService
{
    private readonly ApplicationDbContext _context;

    public AppointmentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAppointmentAsync(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task<Appointment?> GetAppointmentByIdAsync(int id)
    {
        return await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);
    }
}
