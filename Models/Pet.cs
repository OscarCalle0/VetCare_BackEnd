using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VetCare_BackEnd.Models
{
    [Table("pets")]
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
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "The input format should be like: yyyy-MM-dd.")] //regular expresion for the date yyyy-MM-dd
        [StringLength(10, MinimumLength = 10, ErrorMessage = "The Date should have exactly 10 characters.")]  
        public DateOnly BirthDate { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The input is too long")]
        public required string Sex { get; set; }
        public string? ImagePath { get; set; }

        // Foreign keys
        public int user_id { get; set; }

        // Navigation properties
        [NotMapped]
        [ForeignKey("user_id")]
        public User? User { get; set; }
    }
}