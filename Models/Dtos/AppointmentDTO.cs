using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VetCare_BackEnd.Models.Dtos;
public class AppointmentRequestDto
{
    public int UserId { get; set; }
    public int PetId { get; set; }
    public int AppointmentTypeId { get; set; }
    public DateTime EndDate { get; set; }
    public string? Description { get; set; }
}
