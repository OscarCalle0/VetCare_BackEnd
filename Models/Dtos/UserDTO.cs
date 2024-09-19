namespace VetCare_BackEnd.Models.Dtos;
public class UserDTO
{
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public DateOnly? BirthDate { get; set; }
    public required string DocumentNumber { get; set; }
    public required string Password { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required int DocumentTypeId { get; set; }
    public required int RoleId { get; set; }

}