using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetCare_BackEnd.Models;

namespace VetCare_BackEnd.Services.Interfaces
{
    public interface IAppointmentTypeService
    {
        Task<AppointmentType> GetAppointmentTypeByIdAsync(int id);
    }
}