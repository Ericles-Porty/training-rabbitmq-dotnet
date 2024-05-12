using Eris.Rabbit.Store.Application.CQRS.Commands.ProducerCommands;
using Eris.Rabbit.Store.Application.CQRS.Queries.ProducerQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eris.Rabbit.Store.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProducerController : ControllerBase
{
    private readonly ILogger<ProducerController> _logger;
    private readonly IMediator _mediator;

    public ProducerController(ILogger<ProducerController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ProducePurchases()
    {
        var random = new Random();

        var command = new ProducePurchaseCommand
        {
            ProductId = 2,
            Quantity = random.Next(1, 10),
            Total = random.Next(100, 1000)
        };
        var products = await _mediator.Send(command);
        return Ok(products);
    }
}