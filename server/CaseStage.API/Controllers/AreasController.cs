using CaseStage.API.Data;
using CaseStage.Application.Areas.Models;
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
        public async Task<ActionResult<List<AreaModel>>> RetrieveAll()
        {
            return Ok(await _dataContext.Areas.ToListAsync());
            //return await _mediator.Send(new GetAreaListQuery());
        }

        [HttpPost]
        public async Task<ActionResult<List<AreaModel>>> CreateArea(AreaModel area)
        {
            _dataContext.Areas.Add(area);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Areas.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<AreaModel>>> UpdateArea(AreaModel area)
        {
            var dbArea = await _dataContext.Areas.FindAsync(area.Id);

            if (dbArea == null)
                return BadRequest("Area nao encontrada.");

            dbArea.Name = area.Name;
            dbArea.Active = area.Active;
            dbArea.UpdatedAt = DateTime.Now;

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Areas.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<AreaModel>>> DeleteArea(int id)
        {
            var dbArea = await _dataContext.Areas.FindAsync(id);

            if (dbArea == null)
                return BadRequest("Area nao encontrada.");

            _dataContext.Areas.Remove(dbArea);

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Areas.ToListAsync());
        }

    }
}
