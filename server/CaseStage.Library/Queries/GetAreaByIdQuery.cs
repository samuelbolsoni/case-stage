using CaseStage.Library.Models;
using MediatR;

namespace CaseStage.Library.Queries
{
    public record GetAreaByIdQuery(int idArea) : IRequest<AreaModel>;
}
