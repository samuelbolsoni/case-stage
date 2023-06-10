using CaseStage.API.Infrastructure.Interfaces;
using CaseStage.API.Models;
using MediatR;

namespace CaseStage.API.Features.ProccessFeatures.Queries
{
    public class GetProccessByIdQuery : IRequest<Proccess>
    {
        public int Id { get; set; }
        public class GetProccessByIdQueryHandler : IRequestHandler<GetProccessByIdQuery, Proccess>
        {
            private readonly IProccessRepository _proccessRepository;
            public GetProccessByIdQueryHandler(IProccessRepository proccessRepository)
            {
                _proccessRepository = proccessRepository;
            }
            public async Task<Proccess> Handle(GetProccessByIdQuery query, CancellationToken cancellationToken)
            {
                return await _proccessRepository.GetProccessById(query.Id);
            }
        }
    }
}
