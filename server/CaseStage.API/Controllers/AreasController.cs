using CaseStage.API.Data;
using CaseStage.Application.Areas.Commands;
using CaseStage.Application.Areas.Models;
using CaseStage.Application.Areas.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseStage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly DataContext _dataContext;
        public AreasController(IMediator mediator, DataContext dataContext)
        {
            _mediator = mediator;
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<AreaModel>>> Get()
        {
            return Ok(await _dataContext.Areas.ToListAsync());
            return await _mediator.Send(new GetAreaListQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AreaModel>> GetById(int id)
        {
            return await _mediator.Send(new GetAreaByIdQuery(id));
        }

        [HttpPost]
        public async Task<ActionResult<AreaModel>> AddArea(AreaModel areaModel)
        {
            return await _mediator.Send(new AddAreaCommand(areaModel));
        }
    }
}
