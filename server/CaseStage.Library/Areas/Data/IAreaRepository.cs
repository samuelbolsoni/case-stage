using CaseStage.Application.Areas.Models;

namespace CaseStage.Application.Repository
{
    public interface IAreaRepository
    {
        List<AreaModel> GetAreas();
        AreaModel AddArea(AreaModel area);
    }
}
