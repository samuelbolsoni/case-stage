using CaseStage.API.Context;
using CaseStage.API.Infrastructure.Interfaces;
using CaseStage.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseStage.API.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IApplicationContext _context;

        public PersonRepository(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAllPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetPersonById(int id)
        {
            return await _context.Persons.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> Create(Person person)
        {
            _context.Persons.Add(person);
            return _context.SaveChanges();
        }

        public Task<int> Update(Person person)
        {
            return _context.SaveChanges();
        }

        public Task<int> Delete(Person person)
        {
            _context.Persons.Remove(person);
            return _context.SaveChanges();
        }
    }
}
