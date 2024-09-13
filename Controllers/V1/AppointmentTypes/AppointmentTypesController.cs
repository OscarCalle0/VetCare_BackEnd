using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VetCare_BackEnd.Data;

namespace VetCare_BackEnd.Controllers.V1.AppointmentTypes
{
    [ApiController]
    [Route("api/v1/appointmentTypes")]
    public partial class AppointmentTypesController : ControllerBase
    {
         private readonly ApplicationDbContext _context;

        public AppointmentTypesController(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}