using CaseStage.API.Infrastructure.Interfaces;
using MediatR;

namespace CaseStage.API.Features.SystemAppFeatures.Commands
{
    public class UpdateSystemAppCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public class UpdateSystemAppCommandHandler : IRequestHandler<UpdateSystemAppCommand, int>
        {
            private readonly ISystemAppRepository _systemAppRepository;
            public UpdateSystemAppCommandHandler(ISystemAppRepository systemAppRepository)
            {
                _systemAppRepository = systemAppRepository;
            }
            public async Task<int> Handle(UpdateSystemAppCommand command, CancellationToken cancellationToken)
            {
                var systemApp = await _systemAppRepository.GetSystemAppById(command.Id);

                if (systemApp == null)
                {
                    return default;
                }
                else
                {
                    systemApp.Name = command.Name;
                    systemApp.Active = command.Active;
                    systemApp.UpdatedAt = DateTime.Now;

                    var result = _systemAppRepository.Update(systemApp);

                    if (result.IsFaulted)
                        throw new Exception("Erro ao atualizar Sistema.");

                    return systemApp.Id;
                }
            }
        }
    }
}
