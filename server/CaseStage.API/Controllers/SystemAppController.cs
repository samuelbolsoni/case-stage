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

        /// <summary>
        /// Criar um novo sistema
        /// </summary>
        /// <returns>ID do sistema</returns>
        /// <response code="200">Retorna o novo sistema criada</response>
        /// <response code="400">Sistema é nulo</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateSystemAppCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Retorna todos os sistemas
        /// </summary>
        /// <returns>List de Sistemas</returns>
        /// <response code="200">Retorna todas os sistemas</response>
        /// <response code="400">Sistema é nulo</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllSystemAppsQuery()));
        }

        /// <summary>
        /// Retorna os sistema pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Sistema</returns>
        /// <response code="200">Retorna o sistema pelo ID</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetSystemAppByIdQuery { Id = id }));
        }

        /// <summary>
        /// Deleta os sistema pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Sistema</returns>
        /// <response code="200">Deleta o sistema pelo ID</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteSystemAppByIdCommand { Id = id }));
        }

        /// <summary>
        /// Atualiza os sistema pelo ID
        /// </summary>
        /// <param name="id">ID do Sistema</param>
        /// <param name="command">UpdateSystemAppCommand</param>
        /// <returns>Sistema</returns>
        /// <response code="200">Atualiza o sistema pelo ID</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
