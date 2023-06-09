using CaseStage.API.Infrastructure.Interfaces;
using CaseStage.API.Models;
using MediatR;

namespace CaseStage.API.Features.PersonFeatures.Queries
{
    public class GetAllPersonsQuery : IRequest<IEnumerable<Person>>
    {
        public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, IEnumerable<Person>>
        {
            private readonly IPersonRepository _personRepository;
            public GetAllPersonsQueryHandler(IPersonRepository personRepository)
            {
                _personRepository = personRepository;
            }

            public async Task<IEnumerable<Person>> Handle(GetAllPersonsQuery query, CancellationToken cancellationToken)
            {
                var areaList = await _personRepository.GetAllPersons();

                if (areaList == null)
                {
                    return null;
                }
                return areaList;
            }
        }
    }
}
