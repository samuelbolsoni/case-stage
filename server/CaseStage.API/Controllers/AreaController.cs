using CaseStage.API.Features.AreaFeatures.Commands;
using CaseStage.API.Features.AreaFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CaseStage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        /// <summary>
        /// Criar uma nova área
        /// </summary>
        /// <returns>ID da área</returns>
        /// <response code="200">Retorna a nova área criada</response>
        /// <response code="400">Área é nula</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateAreaCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Retorna todas as áreas
        /// </summary>
        /// <returns>List de Area</returns>
        /// <response code="200">Retorna todas as áreas</response>
        /// <response code="400">Área é nula</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllAreasQuery()));
        }

        /// <summary>
        /// Retorna a área pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Area</returns>
        /// <response code="200">Retorna a área pelo ID</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetAreaByIdQuery { Id = id }));
        }

        /// <summary>
        /// Deleta a área pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ID da Area</returns>
        /// <response code="200">Deleta a área pelo ID</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteAreaByIdCommand { Id = id }));
        }

        /// <summary>
        /// Atualiza a área pelo ID
        /// </summary>
        /// <param name="id">ID da Area</param>
        /// <param name="command">UpdateAreaCommand</param>
        /// <returns>ID da Area</returns>
        /// <response code="200">Atualiza a área pelo ID</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, UpdateAreaCommand command)
        {
            if (command.Id == 0)
                command.Id = id;

            return Ok(await Mediator.Send(command));
        }
    }
}
