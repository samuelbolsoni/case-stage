using CaseStage.API.Infrastructure.Interfaces;
using CaseStage.API.Models;
using MediatR;

namespace CaseStage.API.Features.AreaFeatures.Queries
{
    public class GetAreaProccessTreeQuery : IRequest<Dictionary<string, List<string>>>
    {
        public class GetAreaProccessTreeQueryHandler : IRequestHandler<GetAreaProccessTreeQuery, Dictionary<string, List<string>>>
        {
            private readonly IAreaRepository _areaRepository;
            private readonly IProccessRepository _proccessRepository;

            public GetAreaProccessTreeQueryHandler(IAreaRepository areaRepository, IProccessRepository proccessRepository)
            {
                _areaRepository = areaRepository;
                _proccessRepository = proccessRepository;
            }

            public async Task<Dictionary<string, List<string>>> Handle(GetAreaProccessTreeQuery query, CancellationToken cancellationToken)
            {
                var areaList = _areaRepository.GetAllAreas().Result;

                var treeList = new Dictionary<string, List<string>>();

                if (areaList != null)
                {

                    var areaNode = string.Empty;
                    foreach (var area in areaList)
                    {
                        areaNode = area.Name;

                        var proccessList = _proccessRepository.GetProccessByAreaId(area.Id).Result;
                        var proccessNode = new List<string>();

                        foreach(var proccess in proccessList)
                        {
                            proccessNode.Add(proccess.Description);
                        }
                        treeList.Add(areaNode, proccessNode);
                    }
                }

                return treeList;
            }
        }
    }
}
