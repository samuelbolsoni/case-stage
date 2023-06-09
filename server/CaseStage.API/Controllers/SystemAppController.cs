using CaseStage.API.Features.SystemAppFeatures.Commands;
using CaseStage.API.Features.SystemAppFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CaseStage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemAppController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateSystemAppCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllSystemAppsQuery()));
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetSystemAppByIdQuery { Id = id }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteSystemAppByIdCommand { Id = id }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSystemAppCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
