using System.ComponentModel.DataAnnotations;

namespace ConstructionSubmittal_API.Models.DTOs
{
    public class ProjectCreateDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string ProjectNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
