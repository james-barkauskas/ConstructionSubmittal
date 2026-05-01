using ConstructionSubmittal_API.Data;
using ConstructionSubmittal_API.Models;
using ConstructionSubmittal_API.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace ConstructionSubmittal_API.Services
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _db;
        public ProjectService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Project?> CreateProjectAsync(Project project)
        {
            var exists = await _db.Projects.AnyAsync(u => u.JobNumber == project.JobNumber);
            if (exists) { return null; }

            await _db.AddAsync(project);
            await _db.SaveChangesAsync();

            return project;

            //var projectFromDb = _db.Projects.FirstOrDefault(u => u.JobNumber == project.JobNumber);
            //if (projectFromDb==null)
            //{
            //    await _db.Projects.AddAsync(project);
            //    await _db.SaveChangesAsync();
                
            //}

            //else { return null; }
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Project?> GetProjectByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Project?> UpdateProjectAsync(int id, Project project)
        {
            throw new NotImplementedException();
        }
    }
}
