using MediatR;
using Microsoft.AspNetCore.Mvc;
using TCMApp.Application.UseCases.AddTrainComponent;
using TCMApp.Application.UseCases.DeleteTrainComponent;
using TCMApp.Application.UseCases.GetTrainComponent;
using TCMApp.Application.UseCases.GetTrainComponentList;
using TCMApp.Application.UseCases.Models;
using TCMApp.Application.UseCases.UpdateTrainComponent;

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

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TrainComponentResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TrainComponentResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateTrainComponent(int id, UpdateTrainComponentRequest request, CancellationToken cancellationToken)
        {
            if (id != request.Id)
            {
                return BadRequest("Id does not match");
            }

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