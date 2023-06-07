using CaseStage.Application.Areas.Models;
using CaseStage.Application.Areas.Queries;
using CaseStage.Application.Repository;
using MediatR;

namespace CaseStage.Application.Areas.Handlers
{
    public class GetAreaListHandler : IRequestHandler<GetAreaListQuery, List<AreaModel>>
    {
        private readonly IAreaRepository _areaRepository;

        public GetAreaListHandler(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public Task<List<AreaModel>> Handle(GetAreaListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_areaRepository.GetAreas());
        }
    }
}
