using ConstructionSubmittal_API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionSubmittal_API.Models
{
    public class Submittal
    {
        public int Id { get; set; } // will be PK
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        public string? SpecSection { get; set; }

        // Using enums for restricted choices
        public SubmittalStatus Status { get; set; } // int and enum are Value types.. so they cannot be null and are required by default already - dont need [Requried]
        public SubmittalType Type { get; set; }

        // Relationship to Project
        //[ForeignKey]   // don't need to use this attribute b/c .NET knows that ProjectId will be a FK that points to the Project entity and maps to an Id.. only need this attribute if the name is something different/non-standard
        public int ProjectId { get; set; }  // FK to a Project, what the Db uses.. it maps to an existing Project's Id..
        public Project? Project { get; set; }   // Nav property - this is a full Project obj. Allows you to view the Project's properties (Name, JobNumber) w/o having to write a new query..
        // nav properties map your submittal to its parent Project's details.. ex: can do 'submittal.Project.Name' to access the submittals's Project's name..

        // Project is a one-many relatinoship with Submitalls. One Project can have many Submittals.
        // The 'many' side (Submittal) gets the FK and nav property.
    }
}
