using MediatR;
using GallowSoft.Household.Application.InventoryItem;
// Step 1: Define the Query
public record GetInventoryItemsQuery() : IRequest<IEnumerable<InventoryItemReadDto>>;
