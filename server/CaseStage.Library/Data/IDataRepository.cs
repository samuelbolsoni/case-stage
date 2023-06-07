using CaseStage.Library.Models;

namespace CaseStage.Library.Data
{
    public interface IDataRepository
    {
        List<AreaModel> GetAreas();
        AreaModel AddArea (AreaModel area);
    }
}
