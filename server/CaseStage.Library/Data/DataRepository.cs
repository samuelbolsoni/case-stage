using CaseStage.Library.Models;

namespace CaseStage.Library.Data
{
    public class DataRepository : IDataRepository
    {
        private static List<AreaModel> _areas = new()
        {
            new AreaModel { Id = 1, Name = "Area 1" },
            new AreaModel { Id = 2, Name = "Area 2" }
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
