using CaseStage.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseStage.API.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<Area> Areas { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
