using Microsoft.AspNetCore.Mvc;
using TCMApp.Server.Core.Interfaces;

namespace TCMApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TrainComponentsController(ITrainComponentService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetTrainComponents(CancellationToken cancellationToken)
    {
        var result = await service.GetTrainComponentsAsync(cancellationToken);
        return Ok(result);
    }
}
