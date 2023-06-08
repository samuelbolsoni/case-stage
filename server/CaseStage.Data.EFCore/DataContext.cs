using CaseStage.Application.Areas.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseStage.Data.EFCore
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<AreaModel> Areas => Set<AreaModel>();
    }
}
