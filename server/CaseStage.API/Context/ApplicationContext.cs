using CaseStage.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseStage.API.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<Area> Areas { get; set; }
        public DbSet<Proccess> Proccess { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<SystemApp> SystemApps { get; set; }
        public DbSet<ProccessFile> ProccessFiles { get; set; }
        public DbSet<ProccessPerson> ProccessPerson { get; set; }
        public DbSet<ProccessSystem> ProccessSystems { get; set; }
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public async Task<int> SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
