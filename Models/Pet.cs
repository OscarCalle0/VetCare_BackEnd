using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VetCare_BackEnd.Models
{
    [Table("pets")]
    public class Pet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public int user_id { get; set; }

        // Navigation properties
        [ForeignKey("user_id")]
        public User? User { get; set; }
    }
}