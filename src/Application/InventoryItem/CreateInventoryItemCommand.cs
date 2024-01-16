using MediatR;

namespace GallowSoft.Household.Application.InventoryItem;

public class CreateInventoryItemCommand : IRequest<InventoryItemCreateDto>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
}
