using ConstructionSubmittal_API.Models;

namespace ConstructionSubmittal_API.Services.IServices
{
    public interface ISubmittalService
    {
        Task<IEnumerable<Submittal>> GetAllSubimttalsByProjectAsync(int projectId);
        Task<Submittal?> GetSubmittalByIdAsync(int id);
        Task<Submittal?> CreateSubmittalAsync(Submittal submittal);
        Task<Submittal?> UpdateSubmittalAsync(int id, Submittal submittal);
        Task<bool> DeleteSubmittalAsync(int id);
    }
}
