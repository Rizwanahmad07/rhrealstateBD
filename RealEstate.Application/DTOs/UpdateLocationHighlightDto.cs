using System.ComponentModel.DataAnnotations;
namespace RealEstate.Application.DTOs
{
    public class UpdateLocationHighlightDto
    {
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        public string LocationAddress { get; set; }
        [Required] public string AppId { get; set; }
    }
}
