using CaseStage.API.Features.AreaFeatures.Commands;
using CaseStage.API.Infrastructure.Interfaces;
using MediatR;

namespace CaseStage.API.Features.PersonFeatures.Commands
{
    public class UpdatePersonCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, int>
        {
            private readonly IPersonRepository _personRepository;
            public UpdatePersonCommandHandler(IPersonRepository personRepository)
            {
                _personRepository = personRepository;
            }
            public async Task<int> Handle(UpdatePersonCommand command, CancellationToken cancellationToken)
            {
                var person = await _personRepository.GetPersonById(command.Id);

                if (person == null)
                {
                    return default;
                }
                else
                {
                    person.Name = command.Name;
                    person.Email = command.Email;
                    person.Active = command.Active;
                    person.UpdatedAt = DateTime.Now;

                    var result = _personRepository.Update(person);

                    if (result.IsFaulted)
                        throw new Exception("Erro ao atualizar Pessoa.");

                    return person.Id;
                }
            }
        }
    }
}
