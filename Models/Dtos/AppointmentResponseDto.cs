using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetCare_BackEnd.Models.Dtos
{
    public class AppointmentResponseDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Available { get; set; }
        public string Description { get; set; }
        public int PetId { get; set; }
        public int AppointmentTypeId { get; set; }
    }
}