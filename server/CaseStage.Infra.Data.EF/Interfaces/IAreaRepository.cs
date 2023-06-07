

namespace CaseStage.Infra.Data.EF.Interfaces
{
    public interface IAreaRepository
    {
        List<AreaModel> GetAreas();
        Area AddArea(Area area);
    }
}
