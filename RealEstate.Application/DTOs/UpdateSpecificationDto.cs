using System.ComponentModel.DataAnnotations;
namespace RealEstate.Application.DTOs
{
    public class UpdateSpecificationDto
    {
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string AppId { get; set; }
    }
}
