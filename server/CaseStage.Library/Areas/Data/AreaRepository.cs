using CaseStage.Application.Areas.Models;

namespace CaseStage.Application.Repository
{
    public class AreaRepository : IAreaRepository
    {
        private static List<AreaModel> _areas = new()
        {
            new AreaModel { Id = 1, Name = "Area 1", Active = true, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
            new AreaModel{ Id = 2, Name = "Area 2", Active = false, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
        };

        public AreaModel AddArea(AreaModel area)
        {
            _areas.Add(area);
            return area;
        }

        public List<AreaModel> GetAreas()
        {
            return _areas;
        }
    }
}
