using CaseStage.Application.Areas.Commands;
using CaseStage.Application.Areas.Models;
using CaseStage.Application.Areas.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CaseStage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AreasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<AreaModel>> Get()
        {
            return await _mediator.Send(new GetAreaListQuery());
        }

        [HttpGet("{id}")]
        public async Task<AreaModel> GetById(int id)
        {
            return await _mediator.Send(new GetAreaByIdQuery(id));
        }

        [HttpPost]
        public async Task<AreaModel> AddArea(AreaModel areaModel)
        {
            return await _mediator.Send(new AddAreaCommand(areaModel));
        }
    }
}
