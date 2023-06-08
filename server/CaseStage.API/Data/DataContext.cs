using CaseStage.Application.Areas.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseStage.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<AreaModel> Areas => Set<AreaModel>();
    }
}
