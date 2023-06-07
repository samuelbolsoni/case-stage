using CaseStage.Application.Areas.Models;
using MediatR;

namespace CaseStage.Application.Areas.Commands
{
    public record AddAreaCommand(AreaModel model) : IRequest<AreaModel>;
}
