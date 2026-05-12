using AutoMapper;
using ConstructionSubmittal_API.Data;
using ConstructionSubmittal_API.Enums;
using ConstructionSubmittal_API.Models;
using ConstructionSubmittal_API.Models.DTOs;
using ConstructionSubmittal_API.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace ConstructionSubmittal_API.Services
{
    public class SubmittalService : ISubmittalService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public SubmittalService(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Submittal?> CreateSubmittalAsync(Submittal submittal)
        {
            // how can i return different responses other than 'null' if project doesn't exist or title already exists..
            var projectExists = await _db.Projects.AnyAsync(p => p.Id == submittal.ProjectId);
            if (!projectExists) { return null; }
            // check if Title exists within same Project..
            var titleExists = await _db.Submittals.AnyAsync(s => s.Title == submittal.Title
                && s.ProjectId == submittal.ProjectId);
            if (titleExists) { return null; }
            submittal.Status = SubmittalStatus.Draft;

            await _db.Submittals.AddAsync(submittal);
            await _db.SaveChangesAsync();
            return submittal;               
        }

        public async Task<bool> DeleteSubmittalAsync(int id)
        {
            // implement 'soft' delete..?
            var submittal = await _db.Submittals.FindAsync(id);
            if (submittal == null) { return false; }
            _db.Submittals.Remove(submittal);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Submittal>> GetAllSubimttalsByProjectAsync(int projectId)
        {
            //bool project = await _db.Projects.AnyAsync(u => u.Id == projectId);
            return await _db.Submittals.Where(s => s.ProjectId == projectId).ToListAsync(); // include Where clause to filter by Project..
        }

        public async Task<Submittal?> GetSubmittalByIdAsync(int id)
        {
            return await _db.Submittals.FindAsync(id);
        }

        public async Task<Submittal?> UpdateSubmittalAsync(int id, SubmittalUpdateDTO submittalDto)
        {
            // should user be able to update a submittal's project? 
            var submittalFromDb = await _db.Submittals.FindAsync(id);
            if (submittalFromDb == null) { return null; }   // submittal doesn't exist
            

            var titleExists = await _db.Submittals.AnyAsync(s => s.Title == submittalDto.Title 
                && s.ProjectId == submittalFromDb.ProjectId && s.Id != id);
            // checks if a submittal exists that has the same title as the dto, the same ProjectId as the dto, and the same id..
            // this prevents a submittal within the same project having a duplicate name

            if (titleExists) { return null; }

            _mapper.Map(submittalDto, submittalFromDb);
            await _db.SaveChangesAsync();
            return submittalFromDb;
            // implement protction against user entering invalid enum..
        }
    }
}
