namespace ConstructionSubmittal_API.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ProjectNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
