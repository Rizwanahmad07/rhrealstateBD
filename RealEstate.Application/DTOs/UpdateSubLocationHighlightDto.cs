using System.ComponentModel.DataAnnotations;
namespace RealEstate.Application.DTOs
{
    public class UpdateSubLocationHighlightDto
    {
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int LocationHighlightId { get; set; }
        [Required] public string AppId { get; set; }
    }
}
