using CaseStage.Library.Data;
using CaseStage.Library.Models;
using CaseStage.Library.Queries;
using MediatR;

namespace CaseStage.Library.Handlers
{
    public class GetAreaListHandler : IRequestHandler<GetAreaListQuery, List<AreaModel>>
    {
        private readonly IDataRepository _dataRepository;

        public GetAreaListHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public Task<List<AreaModel>> Handle(GetAreaListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataRepository.GetAreas());
        }
    }
}
