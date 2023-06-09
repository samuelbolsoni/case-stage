using CaseStage.API.Context;
using CaseStage.API.Infrastructure.Interfaces;
using CaseStage.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseStage.API.Infrastructure.Repositories
{
    public class ProccessRepository : IProccessRepository
    {
        
        private readonly IApplicationContext _context;

        public ProccessRepository(IApplicationContext context) { 
            _context = context;
        }
        
        public async Task<IEnumerable<Proccess>> GetAllProccess()
        {
            return await _context.Proccess
                                 .Include(x => x.Area)
                                 .Include(x => x.Persons)
                                 .Include(x => x.Systems)
                                 .Include(x => x.Files)
                                 .ToListAsync();
        }

        public async Task<Proccess> GetProccessById(int id)
        {
            return await _context.Proccess
                                 .Include(x => x.Area)
                                 .Include(x => x.Persons)
                                 .Include(x => x.Systems)
                                 .Include(x => x.Files)
                                 .Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> Create(Proccess proccess)
        {
            _context.Proccess.Add(proccess);
            return _context.SaveChanges();
        }

        public Task<int> Update(Proccess proccess)
        {
            return _context.SaveChanges();
        }

        public Task<int> Delete(Proccess proccess)
        {
            _context.Proccess.Remove(proccess);
            return _context.SaveChanges();
        }

        public Task<int> CreateProccessPerson(List<ProccessPerson> proccessPersonList)
        {
            _context.ProccessPerson.AddRange(proccessPersonList);
            return _context.SaveChanges();
        }

        public Task<int> CreateProccessSystemApp(List<ProccessSystem> proccessSystemList)
        {
            _context.ProccessSystems.AddRange(proccessSystemList);
            return _context.SaveChanges();
        }

        public Task<int> CreateProccessFile(List<ProccessFile> proccessFileList)
        {
            _context.ProccessFiles.AddRange(proccessFileList);
            return _context.SaveChanges();
        }
    }
}
