using MediatR;

namespace GallowSoft.Household.Application.InventoryItem;

public class CreateInventoryItemCommand : IRequest<InventoryItemDto>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
}

public record InventoryItemDto
{
    public required string Name { get; init; }
    public required string Description { get; init; }
}