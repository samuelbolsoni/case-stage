using CaseStage.Application.Areas.Models;
using CaseStage.Application.Areas.Queries;
using MediatR;

namespace CaseStage.Application.Areas.Handlers
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

            if (area == null)
            {
                throw new Exception("Area nao encontrada");
            }

            return area;
        }
    }
}
