using CaseStage.API.Infrastructure.Interfaces;
using CaseStage.API.Models;
using MediatR;

namespace CaseStage.API.Features.SystemAppFeatures.Queries
{
    public class GetAllSystemAppsQuery : IRequest<IEnumerable<SystemApp>>
    {
        public class GetAllSystemAppsQueryHandler : IRequestHandler<GetAllSystemAppsQuery, IEnumerable<SystemApp>>
        {
            private readonly ISystemAppRepository _systemAppRepository;
            public GetAllSystemAppsQueryHandler(ISystemAppRepository systemAppRepository)
            {
                _systemAppRepository = systemAppRepository;
            }

            public async Task<IEnumerable<SystemApp>> Handle(GetAllSystemAppsQuery query, CancellationToken cancellationToken)
            {
                var systemAppList = await _systemAppRepository.GetAllSystemApps();

                if (systemAppList == null)
                {
                    return null;
                }
                return systemAppList;
            }
        }
    }
}
