using CaseStage.API.Features.ProccessFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CaseStage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class ProccessTreeController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        /// <summary>
        /// Retorna todas as áreas
        /// </summary>
        /// <returns>List de Area</returns>
        /// <response code="200">Retorna todas as áreas</response>
        /// <response code="400">Área é nula</response>
        [HttpGet]
        [Route("GetProccessTree")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProccessTree()
        {
            return Ok(await Mediator.Send(new GetProccessTreeQuery()));
        }
    }
}
