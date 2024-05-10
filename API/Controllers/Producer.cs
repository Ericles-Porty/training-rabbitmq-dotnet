using Microsoft.AspNetCore.Mvc;

namespace Eris.Rabbit.Store.API.Controllers;

public class Producer : ControllerBase
{
    private readonly ILogger<Producer> _logger;
    private readonly IProducerService _producerService;

    public Producer(ILogger<Producer> logger, IProducerService producerService)
    {
        _logger = logger;
        _producerService = producerService;
    }

    [HttpPost]
    public async Task<IActionResult> Produce([FromBody] ProduceRequest request)
    {
        await _producerService.Produce(request);
        return Ok();
    }
}