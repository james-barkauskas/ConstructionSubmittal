using AutoMapper;
using ConstructionSubmittal_API.Data;
using ConstructionSubmittal_API.Models;
using ConstructionSubmittal_API.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace ConstructionSubmittal_API.Services
{
    // services only know about database and C#... don't know the 'internet' and status codes, etc...
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        public ProjectService(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
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
            var projectFromDb = await _db.Projects.FindAsync(id);
            if (projectFromDb == null) { return false; }
            _db.Projects.Remove(projectFromDb);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            //var projects = await _db.Projects.ToListAsync();
            //return projects;
            return await _db.Projects.ToListAsync();    // can make this one line.. don't need to declare 'projects' varible to return it..
        }

        public async Task<Project?> GetProjectByIdAsync(int id)
        {
            // can also make one line.. if obj doesn't exist by the id, it will return null anyway.. since all i'm doing is retrieving the obj and not doing anything with it.. just one line works
            return await _db.Projects.FindAsync(id);    // using Find is better/quicker than FirstOrDefault.. use Find when looking something up by Id..
            //var project = await _db.Projects.FirstOrDefaultAsync(u => u.Id == id);
            //if (project == null)
            //{
            //    return null;
            //}
            //else
            //{
            //    return project;
            //}
            
        }

        public async Task<Project?> UpdateProjectAsync(int id, Project project)
        {
            var projectFromDb = await _db.Projects.FindAsync(id);
            if (projectFromDb == null) { return null; }

            
            _mapper.Map(project, projectFromDb);  // map the project passed in to the project alrady being tracked by efcore
            await _db.SaveChangesAsync();
            return projectFromDb;
            //if (projectFromDb.Id != project.Id) { return null; } already checked in controller.. don't need here again
        }
    }
}
