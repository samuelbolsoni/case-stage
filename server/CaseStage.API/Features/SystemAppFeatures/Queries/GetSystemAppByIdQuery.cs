using CaseStage.API.Infrastructure.Interfaces;
using CaseStage.API.Models;
using MediatR;

namespace CaseStage.API.Features.SystemAppFeatures.Queries
{
    public class GetSystemAppByIdQuery : IRequest<SystemApp>
    {
        public int Id { get; set; }
        public class GetSystemAppByIdQueryHandler : IRequestHandler<GetSystemAppByIdQuery, SystemApp>
        {
            private readonly ISystemAppRepository _systemAppRepository;
            public GetSystemAppByIdQueryHandler(ISystemAppRepository systemAppRepository)
            {
                _systemAppRepository = systemAppRepository;
            }
            public async Task<SystemApp> Handle(GetSystemAppByIdQuery query, CancellationToken cancellationToken)
            {
                return await _systemAppRepository.GetSystemAppById(query.Id);
            }
        }
    }
}
