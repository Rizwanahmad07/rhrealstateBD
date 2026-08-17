using System.ComponentModel.DataAnnotations;
namespace RealEstate.Application.DTOs
{
    public class UpdateAmentiesDto
    {
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        public string AmentiesImage { get; set; }
        [Required] public string AppId { get; set; }
    }
}
