using System.ComponentModel.DataAnnotations;
namespace RealEstate.Application.DTOs
{
    public class CreateUserDto
    {
        [Required] public string Name { get; set; }
        [Required] public string Mobile { get; set; }
        [Required][EmailAddress] public string Email { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string AppId { get; set; }
    }
}
