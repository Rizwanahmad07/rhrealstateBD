using System.ComponentModel.DataAnnotations;
namespace RealEstate.Application.DTOs
{
    public class CreatePlansDto
    {
        [Required] public string Name { get; set; }
        public string PlanImage { get; set; }
        [Required] public string AppId { get; set; }
    }
}
