using CaseStage.API.Features.PersonFeatures.Queries;
using CaseStage.API.Infrastructure.Interfaces;
using CaseStage.API.Models;
using MediatR;
using System.Xml.Linq;

namespace CaseStage.API.Features.ProccessFeatures.Queries
{
    public class GetProccessTreeQuery : IRequest<IEnumerable<ProccessTree>>
    {
        public class GetProccessTreeQueryHandler : IRequestHandler<GetProccessTreeQuery, IEnumerable<ProccessTree>>
        {
            private readonly IProccessRepository _proccessRepository;
            public GetProccessTreeQueryHandler(IProccessRepository proccessRepository)
            {
                _proccessRepository = proccessRepository;
            }

            public async Task<IEnumerable<ProccessTree>> Handle(GetProccessTreeQuery query, CancellationToken cancellationToken)
            {
                var proccessTree = new List<ProccessTree>();

                var allProccess = _proccessRepository.GetAllProccess().Result;

                foreach (var proccess in allProccess)
                {
                    var childrensProccess = GetChildren(allProccess.ToList(), proccess.Id);

                    var newProccessChildren = new List<ProccessTree>()
                    {
                        new ProccessTree
                        {
                            Id = proccess.Id,
                            IdParent = proccess.IdParent,
                            Description = proccess.Description,
                            Childrens = childrensProccess,
                        }
                    };
                    
                    proccessTree.AddRange(newProccessChildren);

                }
                return proccessTree;
            }
        
            public List<Proccess> GetChildren(List<Proccess> proccess, int? parentId)
            {
                var resultado = proccess
                        .Where(c => c.IdParent == parentId)
                        .Select(c => new Proccess
                        {
                            Id = c.Id,
                            IdParent = c.IdParent,
                            Description = c.Description
                        })
                        .ToList();

                return resultado;
            }
        }
    }
}
