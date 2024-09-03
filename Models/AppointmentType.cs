using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VetCare_BackEnd.Models
{
    [Table("appointmentTypes")]
    public class AppointmentType
    {
        [Key]
        public int Id { get; set; }
        
    }
}