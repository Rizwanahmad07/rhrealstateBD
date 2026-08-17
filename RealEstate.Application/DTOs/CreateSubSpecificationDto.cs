using System.ComponentModel.DataAnnotations;
namespace RealEstate.Application.DTOs
{
    public class CreateSubSpecificationDto
    {
        [Required] public string Name { get; set; }
        [Required] public int SpecificationId { get; set; }
        [Required] public string AppId { get; set; }
    }
}
