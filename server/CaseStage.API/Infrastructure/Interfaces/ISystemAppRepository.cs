using CaseStage.API.Models;

namespace CaseStage.API.Infrastructure.Interfaces
{
    public interface ISystemAppRepository
    {
        Task<IEnumerable<SystemApp>> GetAllSystemApps();
        Task<SystemApp> GetSystemAppById(int id);
        Task<int> Create(SystemApp systemApp);
        Task<int> Update(SystemApp systemApp);
        Task<int> Delete(SystemApp systemApp);
    }
}
