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

        // The enums will send back the int value of the status.. will need to find a way to provide the actual name 'draft', etc.
        public SubmittalStatus Status { get; set; } // int and enum are Value types.. so they cannot be null and are required by default already - dont need [Requried]
        public SubmittalType Type { get; set; }
        public int ProjectId { get; set; }
    }
}
