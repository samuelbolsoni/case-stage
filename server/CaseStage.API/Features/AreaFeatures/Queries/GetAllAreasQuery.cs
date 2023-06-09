using CaseStage.API.Infrastructure.Interfaces;
using CaseStage.API.Models;
using MediatR;

namespace CaseStage.API.Features.AreaFeatures.Queries
{
    public class GetAllAreasQuery : IRequest<IEnumerable<Area>>
    {
        public class GetAllAreasQueryHandler : IRequestHandler<GetAllAreasQuery, IEnumerable<Area>>
        {
            private readonly IAreaRepository _areaRepository;
            public GetAllAreasQueryHandler(IAreaRepository areaRepository)
            {
                _areaRepository = areaRepository;
            }

            public async Task<IEnumerable<Area>> Handle(GetAllAreasQuery query, CancellationToken cancellationToken)
            {
                var areaList = await _areaRepository.GetAllAreas();

                if (areaList == null)
                {
                    return null;
                }
                return areaList;
            }
        }
    }
}
