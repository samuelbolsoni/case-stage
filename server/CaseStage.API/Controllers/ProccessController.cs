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

        /// <summary>
        /// Criar um novo processo
        /// </summary>
        /// <returns>ID do processo</returns>
        /// <response code="200">Retorna o novo processo criada</response>
        /// <response code="400">Processo é nulo</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateProccessCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Retorna todos os processos
        /// </summary>
        /// <returns>List de Processos</returns>
        /// <response code="200">Retorna todas os processos</response>
        /// <response code="400">Processo é nulo</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllProccessQuery()));
        }

        /// <summary>
        /// Retorna o processo pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Sistema</returns>
        /// <response code="200">Retorna o processo pelo ID</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetProccessByIdQuery { Id = id }));
        }

        /// <summary>
        /// Deleta o processo pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Sistema</returns>
        /// <response code="200">Deleta o processo pelo ID</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteProccessByIdCommand { Id = id }));
        }

        /// <summary>
        /// Atualiza o processo pelo ID
        /// </summary>
        /// <param name="id">ID do processo</param>
        /// <param name="command">UpdateProccessCommand</param>
        /// <returns>Sistema</returns>
        /// <response code="200">Atualiza o processo pelo ID</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, UpdateProccessCommand command)
        {
            if (command.Id == 0)
                command.Id = id;

            return Ok(await Mediator.Send(command));
        }
    }
}
