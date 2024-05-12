using Eris.Rabbit.Store.Application.CQRS.Commands.ConsumerCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConsumerController : ControllerBase
{
    private readonly ILogger<ConsumerController> _logger;
    private readonly IMediator _mediator;

    public ConsumerController(ILogger<ConsumerController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ConsumePurchases()
    {
        var processedPurchases = await _mediator.Send(new ConsumePurchasesCommand());
        return Ok(processedPurchases);
    }
}