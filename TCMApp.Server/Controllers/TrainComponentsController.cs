using MediatR;
using Microsoft.AspNetCore.Mvc;
using TCMApp.Server.UseCases.AddTrainComponent;
using TCMApp.Server.UseCases.DeleteTrainComponent;
using TCMApp.Server.UseCases.GetTrainComponent;
using TCMApp.Server.UseCases.GetTrainComponentList;
using TCMApp.Server.UseCases.Models;
using TCMApp.Server.UseCases.UpdateTrainComponent;

namespace TCMApp.Server.Controllers
{
    [Route("api/train-components")]
    [ApiController]
    public class TrainComponentsController(ISender mediator) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(GetTrainComponentListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TrainComponentResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTrainComponents([FromQuery] GetTrainComponentListRequest request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken);
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

            return Ok(result.Value);
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

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TrainComponentResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TrainComponentResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteTrainComponent(int id, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new DeleteTrainComponentRequest(id), cancellationToken);
            if (!result.Succeeded)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }
    }
}