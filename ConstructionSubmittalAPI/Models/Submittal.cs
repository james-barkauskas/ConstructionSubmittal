using ConstructionSubmittal_API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionSubmittal_API.Models
{
    // Project has a one-many relatinoship with Submitalls. One Project can have many Submittals.
    // The 'many' side (Submittal) gets the FK and nav property.
    public class Submittal
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        public string? SpecSection { get; set; }
        // Using enums for restricted choices
        public SubmittalStatus Status { get; set; } // int and enum are Value types.. so they cannot be null and are required by default already - dont need [Requried]
        public SubmittalType Type { get; set; }

        // Relationship to Project
        public int ProjectId { get; set; }  // FK to a Project, what the Db uses.. it maps to an existing Project's Id..
        public Project? Project { get; set; }   // Nav property - this is a full Project obj. Allows you to view the Project's properties (Name, JobNumber) w/o having to write a new query..

        // will need 2 properties: AssignedTo to link to which company owes this submittal; CreatedBy to link to a User that created the submittal..
        // will need a 'history log' where every time an action happens like passing a submittal along, it gets tracked by a log.. would this be a new entity/class??
    }
}
