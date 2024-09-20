using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VetCare_BackEnd.Data;
using VetCare_BackEnd.Services;
using VetCare_BackEnd.Services.Interfaces;
using VetCare_BackEnd.Controllers.V1.Appointments;
using Microsoft.AspNetCore.Authorization;
using VetCare_BackEnd.Models;
using System;
using System.Threading.Tasks;
using System.Threading.Tasks;


namespace VetCare_BackEnd.Controllers.V1.Appointments
{
    [ApiController]
    [Route("api/v1/appointments")]
    [Authorize]
    public partial class AppointmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAppointmentService _appointmentService;
        private readonly IUserService _userService;
        private readonly IPetService _petService;
        private readonly IEmailService _emailService;
        private readonly IAppointmentTypeService _appointmentTypeService;
        private readonly JwtService _jwtService;

        public AppointmentController(ApplicationDbContext context,
            IAppointmentService appointmentService,
            IUserService userService,
            IPetService petService,
            IEmailService emailService,
            IAppointmentTypeService appointmentTypeService,
            JwtService jwtService)
        {
            _context = context;
            _appointmentService = appointmentService;
            _userService = userService;
            _petService = petService;
            _emailService = emailService;
            _appointmentTypeService = appointmentTypeService;
            _jwtService = jwtService;
        }
    }
}

