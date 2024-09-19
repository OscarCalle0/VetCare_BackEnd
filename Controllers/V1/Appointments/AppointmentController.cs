using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VetCare_BackEnd.Data;
using VetCare_BackEnd.Services;
using VetCare_BackEnd.Services.Interfaces;
using VetCare_BackEnd.Controllers.V1.Appointments;

namespace VetCare_BackEnd.Controllers.V1.Appointments;
[ApiController]
[Route("api/v1/appointments")]
public partial class AppointmentController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IAppointmentService _appointmentService;
    private readonly IUserService _userService;
    private readonly IPetService _petService;

    public AppointmentController(ApplicationDbContext context, IAppointmentService appointmentService, IUserService userService, IPetService petService)
    {
        _context = context;
        _appointmentService = appointmentService;
        _userService = userService;
        _petService = petService;
    }
}
