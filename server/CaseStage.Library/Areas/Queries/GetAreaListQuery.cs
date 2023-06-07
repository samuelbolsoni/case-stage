using CaseStage.Application.Areas.Models;
using MediatR;

namespace CaseStage.Application.Areas.Queries
{
    public record GetAreaListQuery() : IRequest<List<AreaModel>>;
}
