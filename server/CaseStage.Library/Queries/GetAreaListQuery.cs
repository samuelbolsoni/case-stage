using CaseStage.Library.Models;
using MediatR;

namespace CaseStage.Library.Queries
{
    public record GetAreaListQuery(): IRequest<List<AreaModel>>;
}
