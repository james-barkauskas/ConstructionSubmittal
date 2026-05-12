using ConstructionSubmittal_API.Enums;
using System.ComponentModel.DataAnnotations;

namespace ConstructionSubmittal_API.Models.DTOs
{
    public class SubmittalUpdateDTO
    {
        public int Id { get; set; } // will be PK
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        public string? SpecSection { get; set; }

        // Using enums for restricted choices
        // public SubmittalStatus Status { get; set; }  don't want b/c we will eventually write methods to change a SubmittalStatus..
        public SubmittalType Type { get; set; }
        // public int ProjectId { get; set; } don't need for UpdateDTO b/c we wouldn't want to be able to change a Submittal's Project..
    }
}
