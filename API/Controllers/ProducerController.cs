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
    public async Task<IActionResult> Products()
    {
        var products = await _mediator.Send(new GetProductsQuery());
        return Ok(products);
    }
}