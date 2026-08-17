using System.ComponentModel.DataAnnotations;
namespace RealEstate.Application.DTOs
{
    public class UpdatePlansDto
    {
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        public string PlanImage { get; set; }
        [Required] public string AppId { get; set; }
    }
}
