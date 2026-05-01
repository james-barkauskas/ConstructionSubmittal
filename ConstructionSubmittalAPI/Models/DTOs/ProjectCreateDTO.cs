using System.ComponentModel.DataAnnotations;

namespace ConstructionSubmittal_API.Models.DTOs
{
    public class ProjectCreateDTO
    {
        [Required]  // by adding [Required], this tells the API not to accept any object if it doesn't have a Name value.. it will return a BadRequest right away..
        public string Name { get; set; } = string.Empty;
        [Required]
        public string JobNumber { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
    }
}
