using System.ComponentModel.DataAnnotations;

namespace ConstructionSubmittal_API.Models.DTOs
{
    public class ProjectReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string JobNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
