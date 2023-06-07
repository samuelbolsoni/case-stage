using CaseStage.Application.Areas.Commands;
using CaseStage.Application.Areas.Models;
using CaseStage.Application.Repository;
using MediatR;

namespace CaseStage.Application.Areas.Handlers
{
    public class AddAreaHandler : IRequestHandler<AddAreaCommand, AreaModel>
    {
        private readonly IAreaRepository _areaRepository;

        public AddAreaHandler(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public Task<AreaModel> Handle(AddAreaCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_areaRepository.AddArea(request.model));
        }
    }
}
