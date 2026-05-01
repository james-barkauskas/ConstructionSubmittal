using ConstructionSubmittal_API.Models;

namespace ConstructionSubmittal_API.Services.IServices
{
    public interface IProjectService
    {
        // Read
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project?> GetProjectByIdAsync(int id);

        // Create
        Task<Project?> CreateProjectAsync(Project project);

        // Update
        Task<Project?> UpdateProjectAsync(int id, Project project);

        // Delete
        Task<bool> DeleteProjectAsync(int id);

    }
}
