using CaseStage.Infra.Data.EF.Interfaces;

namespace CaseStage.Infra.Data.EF.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private static List<AreaModel> _areas = new()
        {
            new Area { Id = 1, Name = "Area 1" },
            new Area { Id = 2, Name = "Area 2" }
        };

        public AreaModel AddArea(AreaModel area)
        {
            _areas.Add(area);
            return area;
        }

        public List<Area> GetAreas()
        {
            return _areas;
        }
    }
}
