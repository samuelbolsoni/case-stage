using CaseStage.API.Infrastructure.Interfaces;
using MediatR;

namespace CaseStage.API.Features.SystemAppFeatures.Commands
{
    public class DeleteSystemAppByIdCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteSystemAppByIdCommandHandler : IRequestHandler<DeleteSystemAppByIdCommand, int>
        {
            private readonly ISystemAppRepository _systemAppRepository;

            public DeleteSystemAppByIdCommandHandler(ISystemAppRepository systemAppRepository)
            {
                _systemAppRepository = systemAppRepository;
            }

            public async Task<int> Handle(DeleteSystemAppByIdCommand command, CancellationToken cancellationToken)
            {
                var area = await _systemAppRepository.GetSystemAppById(command.Id);

                if (area == null) return default;

                var result = _systemAppRepository.Delete(area);

                if (result.IsFaulted)
                    throw new Exception("Erro ao deletar Sistema.");

                return area.Id;
            }
        }
    }
}
