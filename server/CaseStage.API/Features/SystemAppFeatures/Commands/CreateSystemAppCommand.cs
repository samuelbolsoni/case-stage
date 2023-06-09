using CaseStage.API.Infrastructure.Interfaces;
using CaseStage.API.Models;
using MediatR;

namespace CaseStage.API.Features.SystemAppFeatures.Commands
{
    public class CreateSystemAppCommand : IRequest<int>
    {
        public string Name { get; set; }
        public bool Active { get; set; }

        public class CreateSystemAppCommandHandler : IRequestHandler<CreateSystemAppCommand, int>
        {
            private readonly ISystemAppRepository _systemAppRepository;
            public CreateSystemAppCommandHandler(ISystemAppRepository systemAppRepository)
            {
                _systemAppRepository = systemAppRepository;
            }

            public async Task<int> Handle(CreateSystemAppCommand command, CancellationToken cancellationToken)
            {
                var systemApp = new SystemApp();

                systemApp.Name = command.Name;
                systemApp.Active = command.Active;

                var result = _systemAppRepository.Create(systemApp);

                if (result.IsFaulted)
                    throw new Exception("Erro ao criar Sistema.");

                return systemApp.Id;
            }
        }
    }
}
