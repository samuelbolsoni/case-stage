using CaseStage.API.Models;

namespace CaseStage.API.Infrastructure.Interfaces
{
    public interface IProccessRepository
    {
        Task<IEnumerable<Proccess>> GetAllProccess();
        Task<Proccess> GetProccessById(int id);
        Task<IEnumerable<Proccess>> GetProccessByAreaId(int areaId);

        Task<int> Create(Proccess proccess);
        Task<int> Update(Proccess proccess);
        Task<int> Delete(Proccess proccess);
        Task<int> CreateProccessPerson(List<ProccessPerson> proccessPersonList);
        Task<int> CreateProccessSystemApp(List<ProccessSystem> proccessSystemList);
        Task<int> CreateProccessFile(List<ProccessFile> proccessFileList);
        Task<int> DeleteProccessPersonByProccessId(List<ProccessPerson> proccessPerson);
        Task<int> DeleteProccessSystemByProccessId(List<ProccessSystem> proccessSystem);
        Task<int> DeleteProccessFileByProccessId(List<ProccessFile> proccessFile);
    }
}
