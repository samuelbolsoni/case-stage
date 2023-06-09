using CaseStage.API.Infrastructure.Interfaces;
using MediatR;

namespace CaseStage.API.Features.PersonFeatures.Commands
{
    public class DeletePersonByIdCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeletePersonByIdCommandHandler : IRequestHandler<DeletePersonByIdCommand, int>
        {
            private readonly IPersonRepository _personRepository;

            public DeletePersonByIdCommandHandler(IPersonRepository personRepository)
            {
                _personRepository = personRepository;
            }

            public async Task<int> Handle(DeletePersonByIdCommand command, CancellationToken cancellationToken)
            {
                var area = await _personRepository.GetPersonById(command.Id);

                if (area == null) return default;

                _personRepository.Delete(area);

                return area.Id;
            }
        }
    }
}
