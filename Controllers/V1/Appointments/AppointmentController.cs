using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VetCare_BackEnd.Data;

namespace VetCare_BackEnd.Controllers.V1.Appointments;
[ApiController]
[Route("api/v1/appointments")]
public partial class AppointmentController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AppointmentController(ApplicationDbContext context)
    {
        _context = context;
    }
}
