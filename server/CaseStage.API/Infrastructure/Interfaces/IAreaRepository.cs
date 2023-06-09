using CaseStage.API.Models;

namespace CaseStage.API.Infrastructure.Interfaces
{
    public interface IAreaRepository
    {
        Task<IEnumerable<Area>> GetAllAreas();
        Task<Area> GetAreaById(int id);
        Task<int> Create(Area area);
        Task<int> Update(Area area);
        Task<int> Delete(Area area);
    }
}
