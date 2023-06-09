using CaseStage.API.Models;

namespace CaseStage.API.Infrastructure.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPersons();
        Task<Person> GetPersonById(int id);
        Task<int> Create(Person person);
        Task<int> Update(Person person);
        Task<int> Delete(Person person);
    }
}
