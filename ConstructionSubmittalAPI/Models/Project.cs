using System.ComponentModel.DataAnnotations;

namespace ConstructionSubmittal_API.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]  // [Required] checks for external validation. It checks the incoming JSON request and if 'Name' is null, .NET will send an error right away.
        public string Name { get; set; } = string.Empty; // 'string.Empty' is for internal validation, sets a default value to the property (""). Helps prevent nullReferenceException
        [Required]
        public string JobNumber { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;

        // adding CompanyId property to map a Project to a GC.. FK to Company..
        // should Project only be able to belong to a GC..?
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }

        // by using [Required], this protects from outside requests.. it tells the API to reject a request if a value is not included..
        // by using string.Empty, this is internal protection.. helps prevent nullReferenceException..
        // should include these validations in both DTOs and entity models..
        // DTOs validate the incoming data from a user, entity model defines how to store data into DB
        // ensures API is safe from moment request hits to when it saves to Db..
        // if a property is truly optional, make it nullable: '?' - wouldn't include the 'string.Empty'..
        // if you wanted to allow users to create a 'draft' project (no Name at creation), could leave off [Required].. but keep string.Empty.. b/c this would say the reqeust doesn't need Name..
        // by including [Required] on DTO and Entity model, it tells DTO what to accept, it tells Db that the property is NOT NULL
        // if you only put [Required] on DTO and not Db model, SQL would mark the Db Column as nullable..

        // Inverse Nav property.. with any Project, can see it's submittalls..
        // public List<Submittal> Submittals { get; set; } = new();    // wouldn't include in my DTOs..
    }
}
