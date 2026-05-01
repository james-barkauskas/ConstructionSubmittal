using System.ComponentModel.DataAnnotations;

namespace ConstructionSubmittal_API.Models.DTOs
{
    public class ProjectUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string JobNumber { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
    }
}
