using ConstructionSubmittal_API.Enums;
using System.ComponentModel.DataAnnotations;

namespace ConstructionSubmittal_API.Models.DTOs
{
    public class CompanyUpdateDTO
    {
        //public int Id { get; set; }   // don't include id here in updateDTO - id will be included from Route..
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public CompanyType CompanyType { get; set; }
        [Required]
        public string Address { get; set; } = string.Empty;
    }
}
