using CaseStage.Library.Models;
using CaseStage.Library.Queries;
using MediatR;
using System.Drawing;

namespace CaseStage.Library.Handlers
{
    public class GetAreaByIdHandler : IRequestHandler<GetAreaByIdQuery, AreaModel>
    {
        private readonly IMediator _mediator;

        public GetAreaByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<AreaModel> Handle(GetAreaByIdQuery request, CancellationToken cancellationToken)
        {
            var areas = await _mediator.Send(new GetAreaListQuery());

            var area = areas.FirstOrDefault(a => a.Id.Equals(request.idArea));

            return area;
        }
    }
}
