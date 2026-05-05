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
            // using anyAsync is good for checking for existence.. if use FirstOrDefault, it returns the obj, which is heavier db query.. and don't always need an obj if just checking for existence..
            var exists = await _db.Projects.AnyAsync(u => u.JobNumber == project.JobNumber);
            if (exists) { return null; }

            await _db.AddAsync(project);
            await _db.SaveChangesAsync();

            return project;

            // what checks to put in services vs controllers?
            // generally - controller checks validation, should not touch db..
            // - services check if data is valid within context of your business logic.. does this ProjectNum alerady exist? does this CompanyId the user provided exist?


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
