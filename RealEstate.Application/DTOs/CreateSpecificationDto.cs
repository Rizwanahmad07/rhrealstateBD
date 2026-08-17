using System.ComponentModel.DataAnnotations;
namespace RealEstate.Application.DTOs
{
    public class CreateSpecificationDto
    {
        [Required] public string Name { get; set; }
        [Required] public string AppId { get; set; }
    }
}
