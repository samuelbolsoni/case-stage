using CaseStage.API.Context;
using CaseStage.API.Infrastructure.Interfaces;
using CaseStage.API.Models;
using MediatR;

namespace CaseStage.API.Features.AreaFeatures.Queries
{
    public class GetAreaByIdQuery : IRequest<Area>
    {
        public int Id { get; set; }
        public class GetAreaByIdQueryHandler : IRequestHandler<GetAreaByIdQuery, Area>
        {
            private readonly IAreaRepository _areaRepository;
            public GetAreaByIdQueryHandler(IAreaRepository areaRepository)
            {
                _areaRepository = areaRepository;
            }
            public async Task<Area> Handle(GetAreaByIdQuery query, CancellationToken cancellationToken)
            {
                return await _areaRepository.GetAreaById(query.Id);
            }
        }
    }
}
