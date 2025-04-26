using MediatR;
using Microsoft.AspNetCore.Mvc;
using TCMApp.Server.UseCases.AddTrainComponent;
using TCMApp.Server.UseCases.GetTrainComponent;
using TCMApp.Server.UseCases.GetTrainComponentList;
using TCMApp.Server.UseCases.Models;
using TCMApp.Server.UseCases.UpdateTrainComponent;

namespace TCMApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainComponentsController(ISender mediator) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(GetTrainComponentListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TrainComponentResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTrainComponents(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetTrainComponentListRequest(), cancellationToken);
            if (!result.Succeeded)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TrainComponentResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TrainComponentResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(TrainComponentResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTrainComponent(int id, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetTrainComponentRequest(id), cancellationToken);
            if (!result.Succeeded)
            {
                return NotFound(result.Message);
            }

            return Ok(result.Value);
        }

        [HttpPost]
        [ProducesResponseType(typeof(TrainComponentResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TrainComponentResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateTrainComponent(AddTrainComponentRequest request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken);
            if (!result.Succeeded)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Value!.Id);
        }

        [HttpPut]
        [ProducesResponseType(typeof(TrainComponentResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TrainComponentResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateTrainComponent(UpdateTrainComponentRequest request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken);
            if (!result.Succeeded)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Value);
        }
    }
}
