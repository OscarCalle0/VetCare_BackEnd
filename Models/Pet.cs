using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VetCare_BackEnd.Models
{
    [Table("Pets")]
    public class Pet
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(100, ErrorMessage = "The input is too long")]
        public required string Name { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "The input is too long")]
        public required string Breed { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "The input is too long")]
        public required string Weight { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The input is too long")]
        public required string Sex { get; set; }

        // Foreign keys
        [ForeignKey("User")]
        public int UserId { get; set; }

        // Navigation properties
        public required User User { get; set; }
    }
}