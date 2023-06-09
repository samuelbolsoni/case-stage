using CaseStage.API.Context;
using CaseStage.API.Infrastructure.Interfaces;
using CaseStage.API.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CaseStage.API.Infrastructure.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        
        private readonly IApplicationContext _context;

        public AreaRepository(IApplicationContext context) { 
            _context = context;
        }
        
        public async Task<IEnumerable<Area>> GetAllAreas()
        {
            return await _context.Areas.ToListAsync();
        }

        public async Task<Area> GetAreaById(int id)
        {
            return await _context.Areas.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> Create(Area area)
        {
            _context.Areas.Add(area);
            return _context.SaveChanges();
        }

        public Task<int> Update(Area area)
        {
            return _context.SaveChanges();
        }

        public Task<int> Delete(Area area)
        {
            _context.Areas.Remove(area);
            return _context.SaveChanges();
        }

    }
}
