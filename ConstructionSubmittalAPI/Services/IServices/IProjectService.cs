using ConstructionSubmittal_API.Models;

namespace ConstructionSubmittal_API.Services.IServices
{
    // all services should be paired with a interface.. critical for dep. inj. (how controller gets access to the service)
    // interface is basically a contract or blueprint for a class to follow.. outlines the methods the class will implement..
    public interface IProjectService    // avoid baseService for now.. maybe add when you have 3-4 services..
    {
        // every method will be wrapped in Task to allow for async.. 
        // Read
        Task<IEnumerable<Project>> GetAllProjectsAsync();   // doesn't need nullable b/c if it's empty, will return an empty list []
        Task<Project?> GetProjectByIdAsync(int id); // by making return type '?', we say we'll either return a Project, or null if it doesn't exist.. try removing ? and grabbing an id that doesn't exist to test..

        // Create
        Task<Project?> CreateProjectAsync(Project project); // we return a Project, b/c if created successfully, we use that obj to grab the id.. should this receive a DTO and do the mapping in here?

        // Update
        Task<Project?> UpdateProjectAsync(int id, Project project);

        // Delete
        Task<bool> DeleteProjectAsync(int id);  // return a bool b/c deleting is a yes/no operation - either obj got deleted (true), or didn't (false)

        // the return types here are what get returned to the controller since the controller calls the service..
        // should my services return the entity to the controller or a dto?
        
    }
}
