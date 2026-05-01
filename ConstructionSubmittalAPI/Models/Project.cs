using System.ComponentModel.DataAnnotations;

namespace ConstructionSubmittal_API.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string JobNumber { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;

        // by using [Required], this protects from outside requests.. it tells the API to reject a request if a value is not included..
        // by using string.Empty, this is internal protection.. helps prevent nullReferenceException..
    }
}
