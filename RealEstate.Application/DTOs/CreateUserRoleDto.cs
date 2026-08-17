using System.ComponentModel.DataAnnotations;
namespace RealEstate.Application.DTOs
{
    public class CreateUserRoleDto
    {
        [Required] public int UserId { get; set; }
        [Required] public int RoleId { get; set; }
        [Required] public string AppId { get; set; }
    }
}
