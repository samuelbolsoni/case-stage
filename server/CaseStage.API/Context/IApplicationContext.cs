using CaseStage.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseStage.API.Context
{
    public interface IApplicationContext
    {
        DbSet<Area> Areas { get; set; }

        Task<int> SaveChanges();
    }
}
