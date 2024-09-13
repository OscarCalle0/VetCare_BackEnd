using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VetCare_BackEnd.Models
{
    [Table("appointments")]
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly EndDate { get; set; }

        [Required]
        public bool Available { get; set; }

        [MaxLength(260, ErrorMessage = "The input is too long")]
        public string? Description { get; set; }

        // Foreign Keys
        public int PetId { get; set; }
        public int AppointmentTypeId { get; set; }

        // Navigation properties
        [NotMapped]
        [ForeignKey("PetId")]
        public required Pet Pet { get; set; }
        [NotMapped]
        [ForeignKey("AppointmentTypeId")]
        public required AppointmentType AppointmentType { get; set; }
    }
}