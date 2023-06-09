using CaseStage.API.Infrastructure.Interfaces;
using CaseStage.API.Models;
using MediatR;

namespace CaseStage.API.Features.PersonFeatures.Queries
{
    public class GetPersonByIdQuery : IRequest<Person>
    {
        public int Id { get; set; }
        public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, Person>
        {
            private readonly IPersonRepository _personRepository;
            public GetPersonByIdQueryHandler(IPersonRepository personRepository)
            {
                _personRepository = personRepository;
            }
            public async Task<Person> Handle(GetPersonByIdQuery query, CancellationToken cancellationToken)
            {
                return await _personRepository.GetPersonById(query.Id);

            }
        }
    }
}
