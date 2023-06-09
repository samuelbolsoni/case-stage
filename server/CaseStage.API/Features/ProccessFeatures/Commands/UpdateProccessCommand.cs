using CaseStage.API.Infrastructure.Interfaces;
using MediatR;

namespace CaseStage.API.Features.ProccessFeatures.Commands
{

    public class UpdateProccessCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int? IdParent { get; set; }
        public int AreaId { get; set; }
        public string Description { get; set; }
        public string Documentation { get; set; }
        public bool Active { get; set; }

        public class UpdateProccessCommandHandler : IRequestHandler<UpdateProccessCommand, int>
        {
            private readonly IProccessRepository _proccessRepository;
            public UpdateProccessCommandHandler(IProccessRepository proccessRepository)
            {
                _proccessRepository = proccessRepository;
            }
            public async Task<int> Handle(UpdateProccessCommand command, CancellationToken cancellationToken)
            {
                var proccess = await _proccessRepository.GetProccessById(command.Id);

                if (proccess == null)
                {
                    return default;
                }
                else
                {
                    proccess.IdParent = command.IdParent;
                    proccess.AreaId = command.AreaId;
                    proccess.Description = command.Description;
                    proccess.Documentation = command.Documentation;
                    proccess.Active = command.Active;
                    proccess.UpdatedAt = DateTime.Now;

                    await _proccessRepository.Update(proccess);
                    return proccess.Id;
                }
            }
        }
    }
}
