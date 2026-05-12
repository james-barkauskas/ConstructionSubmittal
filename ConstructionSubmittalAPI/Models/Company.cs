using ConstructionSubmittal_API.Enums;
using System.ComponentModel.DataAnnotations;

namespace ConstructionSubmittal_API.Models
{
    public class Company
        // a Company can have many Projects.. many Users..
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]  // can include [Required].. already a value type so cannot be null.. but best practice to include [Required]?
        public CompanyType CompanyType { get; set; }
        [Required]
        public string Address { get; set; } = string.Empty;
        // Navigation property - links many Projects to this Company
        //public ICollection<Project> Projects { get; set; } = new List<Project>();

    }
}
