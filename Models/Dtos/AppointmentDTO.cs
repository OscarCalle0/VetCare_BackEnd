using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VetCare_BackEnd.Models.Dtos;
public class AppointmentDTO
{
     [JsonIgnore]
    public DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required bool Available { get; set; }
    public string? Description { get; set; }
    public required int PetId { get; set; }
    public required int AppointmentTypeId { get; set; }
}