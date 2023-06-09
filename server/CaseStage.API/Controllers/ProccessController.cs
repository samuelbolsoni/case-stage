using CaseStage.API.Features.ProccessFeatures.Commands;
using CaseStage.API.Features.ProccessFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CaseStage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProccessController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateProccessCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllProccessQuery()));
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetProccessByIdQuery { Id = id }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteProccessByIdCommand { Id = id }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProccessCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
