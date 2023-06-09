using CaseStage.API.Features.AreaFeatures.Commands;
using CaseStage.API.Infrastructure.Interfaces;
using CaseStage.API.Models;
using MediatR;

namespace CaseStage.API.Features.PersonFeatures.Commands
{
    public class CreatePersonCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
        {
            private readonly IPersonRepository _personRepository;
            public CreatePersonCommandHandler(IPersonRepository personRepository)
            {
                _personRepository = personRepository;
            }
            public async Task<int> Handle(CreatePersonCommand command, CancellationToken cancellationToken)
            {
                var person = new Person();

                person.Name = command.Name;
                person.Email = command.Email;
                person.Active = command.Active;

                var result = _personRepository.Create(person);

                if (result.IsFaulted)
                    throw new Exception("Erro ao criar Pessoa.");

                return person.Id;
            }
        }
    }
}
