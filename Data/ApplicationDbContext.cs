using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Data;

public class ApplicationDbContext:DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<DocumentType> DocumentTypes { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Appointment> Appointments { get; set; }

    public DbSet<Pet> Pets { get; set; }

    public DbSet<AppointmentType> AppointmentTypes { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

}
