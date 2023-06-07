using CaseStage.Library.Models;
using MediatR;

namespace CaseStage.Library.Commands
{
    public record AddAreaCommand(AreaModel model) : IRequest<AreaModel>;
}
