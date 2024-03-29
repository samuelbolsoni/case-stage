﻿using CaseStage.API.Infrastructure.Interfaces;
using CaseStage.API.Models;
using MediatR;

namespace CaseStage.API.Features.ProccessFeatures.Queries
{
    public class GetAllProccessQuery : IRequest<IEnumerable<Proccess>>
    {
        public class GetAllProccessQueryHandler : IRequestHandler<GetAllProccessQuery, IEnumerable<Proccess>>
        {
            private readonly IProccessRepository _proccessRepository;
            public GetAllProccessQueryHandler(IProccessRepository proccessRepository)
            {
                _proccessRepository = proccessRepository;
            }

            public async Task<IEnumerable<Proccess>> Handle(GetAllProccessQuery query, CancellationToken cancellationToken)
            {
                var proccessList = await _proccessRepository.GetAllProccess();

                if (proccessList == null)
                {
                    return null;
                }

                foreach(var proccess in proccessList)
                {
                    if (proccess.IdParent != null)
                    {
                        var nameParent = proccessList.Where(x => x.Id == proccess.IdParent).FirstOrDefault();

                        if (nameParent != null) { 
                            proccess.ParentDescription = nameParent.Description;
                        }
                    }
                }
                return proccessList;
            }
        }
    }
}
