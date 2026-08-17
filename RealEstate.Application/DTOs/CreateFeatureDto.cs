using System.ComponentModel.DataAnnotations;
namespace RealEstate.Application.DTOs
{
    public class CreateFeatureDto
    {
        [Required] public string Name { get; set; }
        public string FeatureImages { get; set; }
        [Required] public string AppId { get; set; }
    }
}
