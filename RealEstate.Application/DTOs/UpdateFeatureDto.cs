using System.ComponentModel.DataAnnotations;
namespace RealEstate.Application.DTOs
{
    public class UpdateFeatureDto
    {
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        public string FeatureImages { get; set; }
        [Required] public string AppId { get; set; }
    }
}
