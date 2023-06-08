using CaseStage.Application.Areas.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseStage.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<AreaModel> Areas => Set<AreaModel>();
        public DbSet<ProccessModel> Proccess => Set<ProccessModel>();
        public DbSet<PersonModel> Person => Set<PersonModel>();
        public DbSet<SystemModel> System => Set<SystemModel>();
        public DbSet<ProccessPerson> ProccessPerson => Set<ProccessPerson>();
        public DbSet<ProccessSystem> ProccessSystem => Set<ProccessSystem>();
    }
}
