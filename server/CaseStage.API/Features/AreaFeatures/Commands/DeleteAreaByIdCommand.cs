using CaseStage.API.Infrastructure.Interfaces;
using CaseStage.API.Infrastructure.Repositories;
using CaseStage.API.Models;
using MediatR;

namespace CaseStage.API.Features.AreaFeatures.Commands
{
    public class DeleteAreaByIdCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteAreaByIdCommandHandler : IRequestHandler<DeleteAreaByIdCommand, int>
        {
            private readonly IAreaRepository _areaRepository;

            public DeleteAreaByIdCommandHandler(IAreaRepository areaRepository)
            {
                _areaRepository = areaRepository;
            }

            public async Task<int> Handle(DeleteAreaByIdCommand command, CancellationToken cancellationToken)
            {
                var area = await _areaRepository.GetAreaById(command.Id);
                if (area == null) return default;

                var result = _areaRepository.Delete(area);

                if (result.IsFaulted)
                    throw new Exception("Erro ao deletar Area.");

                return area.Id;
            }
        } 
    }
}
