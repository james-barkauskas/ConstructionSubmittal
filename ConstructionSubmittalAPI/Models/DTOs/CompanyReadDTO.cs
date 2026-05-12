using ConstructionSubmittal_API.Enums;
using System.ComponentModel.DataAnnotations;

namespace ConstructionSubmittal_API.Models.DTOs
{
    public class CompanyReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public CompanyType CompanyType { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}
