using CaseStage.API.Infrastructure.Interfaces;
using CaseStage.API.Models;
using MediatR;

namespace CaseStage.API.Features.AreaFeatures.Commands
{

    public class CreateAreaCommand : IRequest<int>
    {
        public string Name { get; set; }
        public bool Active { get; set; }

        public class CreateAreaCommandHandler : IRequestHandler<CreateAreaCommand, int>
        {
            private readonly IAreaRepository _areaRepository;
            public CreateAreaCommandHandler(IAreaRepository areaRepository)
            {
                _areaRepository = areaRepository;
            }
            public async Task<int> Handle(CreateAreaCommand command, CancellationToken cancellationToken)
            {
                var area = new Area();

                area.Name = command.Name;
                area.Active = command.Active;

                return _areaRepository.Create(area).Id;
            }
        }
    }
}
