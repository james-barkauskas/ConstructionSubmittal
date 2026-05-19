using ConstructionSubmittal_API.Enums;
using System.ComponentModel.DataAnnotations;

namespace ConstructionSubmittal_API.Models.DTOs
{
    public class SubmittalReadDTO
    {
        public int Id { get; set; } // will be PK
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        public string? SpecSection { get; set; }
        public SubmittalStatus Status { get; set; }
        public SubmittalType Type { get; set; }
        public int ProjectId { get; set; }
    }
}
