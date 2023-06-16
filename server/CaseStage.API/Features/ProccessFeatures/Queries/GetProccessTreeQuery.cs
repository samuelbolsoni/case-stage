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

                var allProccess = ConvertToProccessTree(_proccessRepository.GetAllProccess().Result);

                foreach (var proccess in allProccess)
                {
                    var children = allProccess.Where(x => x.IdParent == proccess.Id);

                    if (children != null && children.Any())
                    {
                        proccess.Childrens.AddRange(children);
                    }
                        
                    if (proccess.IdParent == null)
                        proccessTree.Add(proccess);

                }
                return proccessTree;
            }

            public List<ProccessTree> ConvertToProccessTree(IEnumerable<Proccess> children)
            {
                var treeChildren = new List<ProccessTree>();
                
                foreach (var child in children)
                {
                    treeChildren.Add(new ProccessTree()
                    {
                        Id = child.Id,
                        Description = child.Description,
                        IdParent = child.IdParent
                    });
                }

                return treeChildren;
            }
        }
    }
}
