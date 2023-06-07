using CaseStage.Application.Areas.Models;

namespace CaseStage.Application.Repository
{
    public class AreaRepository : IAreaRepository
    {
        private static List<AreaModel> _areas = new()
        {
            new AreaModel { Id = 1, Name = "Area 1" },
            new AreaModel{ Id = 2, Name = "Area 2" }
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
