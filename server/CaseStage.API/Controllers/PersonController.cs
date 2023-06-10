using CaseStage.API.Features.PersonFeatures.Commands;
using CaseStage.API.Features.PersonFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CaseStage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        /// <summary>
        /// Criar uma nova pessoa
        /// </summary>
        /// <returns>ID da pessoa</returns>
        /// <response code="200">Retorna a nova pessoa criada</response>
        /// <response code="400">Pessoa é nula</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreatePersonCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Retorna todas as pessoas
        /// </summary>
        /// <returns>List de Pessoas</returns>
        /// <response code="200">Retorna todas as pessoas</response>
        /// <response code="400">Pessoa é nula</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllPersonsQuery()));
        }

        /// <summary>
        /// Retorna a pessoa pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Pessoa</returns>
        /// <response code="200">Retorna a pessoa pelo ID</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetPersonByIdQuery { Id = id }));
        }

        /// <summary>
        /// Deleta a pessoa pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Pessoa</returns>
        /// <response code="200">Deleta a pessoa pelo ID</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePersonByIdCommand { Id = id }));
        }

        /// <summary>
        /// Atualiza a pessoa pelo ID
        /// </summary>
        /// <param name="id">ID da Pessoa</param>
        /// <param name="command">UpdatePersonCommand</param>
        /// <returns>Pessoa</returns>
        /// <response code="200">Atualiza a pessoa pelo ID</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, UpdatePersonCommand command)
        {
            if (command.Id == 0)
                command.Id = id;

            return Ok(await Mediator.Send(command));
        }
        
    }
}
