using CaseStage.API.Infrastructure.Interfaces;
using MediatR;

namespace CaseStage.API.Features.ProccessFeatures.Commands
{
    public class DeleteProccessByIdCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteProccessByIdCommandHandler : IRequestHandler<DeleteProccessByIdCommand, int>
        {
            private readonly IProccessRepository _proccessRepository;

            public DeleteProccessByIdCommandHandler(IProccessRepository proccessRepository)
            {
                _proccessRepository = proccessRepository;
            }

            public async Task<int> Handle(DeleteProccessByIdCommand command, CancellationToken cancellationToken)
            {
                var proccess = await _proccessRepository.GetProccessById(command.Id);

                if (proccess == null) return default;

                var result = _proccessRepository.Delete(proccess);

                if (result.IsFaulted)
                    throw new Exception("Erro ao deletar Processo.");

                return proccess.Id;
            }
        } 
    }
}
