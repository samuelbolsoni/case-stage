using CaseStage.API.Infrastructure.Interfaces;
using MediatR;

namespace CaseStage.API.Features.AreaFeatures.Commands
{
    public class UpdateAreaCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public class UpdateAreaCommandHandler : IRequestHandler<UpdateAreaCommand, int>
        {
            private readonly IAreaRepository _areaRepository;
            public UpdateAreaCommandHandler(IAreaRepository areaRepository)
            {
                _areaRepository = areaRepository;
            }
            public async Task<int> Handle(UpdateAreaCommand command, CancellationToken cancellationToken)
            {
                var area = await _areaRepository.GetAreaById(command.Id);

                if (area == null)
                {
                    return default;
                }
                else
                {
                    area.Name = command.Name;
                    area.Active = command.Active;
                    area.UpdatedAt = DateTime.Now;

                    var result = _areaRepository.Update(area);

                    if (result.IsFaulted)
                        throw new Exception("Erro ao criar Area.");

                    return area.Id;
                }
            }
        }
    }
}
