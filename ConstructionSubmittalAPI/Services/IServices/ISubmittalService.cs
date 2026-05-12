using ConstructionSubmittal_API.Models;
using ConstructionSubmittal_API.Models.DTOs;

namespace ConstructionSubmittal_API.Services.IServices
{
    public interface ISubmittalService
    {
        Task<IEnumerable<Submittal>> GetAllSubimttalsByProjectAsync(int projectId);
        Task<Submittal?> GetSubmittalByIdAsync(int id);
        Task<Submittal?> CreateSubmittalAsync(Submittal submittal);
        Task<Submittal?> UpdateSubmittalAsync(int id, SubmittalUpdateDTO submittal);
        Task<bool> DeleteSubmittalAsync(int id);
    }
}
