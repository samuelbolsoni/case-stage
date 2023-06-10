using CaseStage.API.Context;
using CaseStage.API.Infrastructure.Interfaces;
using CaseStage.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseStage.API.Infrastructure.Repositories
{
    public class SystemAppRepository : ISystemAppRepository
    {
        
        private readonly IApplicationContext _context;

        public SystemAppRepository(IApplicationContext context) { 
            _context = context;
        }
        
        public async Task<IEnumerable<SystemApp>> GetAllSystemApps()
        {
            return await _context.SystemApps.ToListAsync();
        }

        public async Task<SystemApp> GetSystemAppById(int id)
        {
            return await _context.SystemApps.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> Create(SystemApp systemApp)
        {
            _context.SystemApps.Add(systemApp);
            return _context.SaveChanges();
        }

        public Task<int> Update(SystemApp systemApp)
        {
            return _context.SaveChanges();
        }

        public Task<int> Delete(SystemApp systemApp)
        {
            _context.SystemApps.Remove(systemApp);
            return _context.SaveChanges();
        }
    }
}
