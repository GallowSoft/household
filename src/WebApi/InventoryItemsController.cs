using GallowSoft.Household.Application.InventoryItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class InventoryItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public InventoryItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<InventoryItemReadDto>>> GetInventoryItems()
    {
        return Ok(await _mediator.Send(new GetInventoryItemsQuery()));
    }

    [HttpPost]
    public async Task<ActionResult<InventoryItemCreateDto>> CreateInventoryItem(CreateInventoryItemCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}