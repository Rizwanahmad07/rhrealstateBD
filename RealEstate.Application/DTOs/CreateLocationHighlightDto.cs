using System.ComponentModel.DataAnnotations;
namespace RealEstate.Application.DTOs
{
    public class CreateLocationHighlightDto
    {
        [Required] public string Name { get; set; }
        public string LocationAddress { get; set; }
        [Required] public string AppId { get; set; }
    }
}
