using ConstructionSubmittal_API.Enums;
using System.ComponentModel.DataAnnotations;

namespace ConstructionSubmittal_API.Models.DTOs
{
    public class SubmittalCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        public string? SpecSection { get; set; }
        // public SubmittalStatus Status { get; set; } // Status will be set to Draft by default..
        public SubmittalType Type { get; set; }
        public int ProjectId { get; set; }  // api needs to know which Project a submittal belongs to
    }
}
