using System.ComponentModel.DataAnnotations;
namespace RealEstate.Application.DTOs
{
    public class CreateRoleDto
    {
        [Required] public string Name { get; set; }
        [Required] public string AppId { get; set; }
    }
}
