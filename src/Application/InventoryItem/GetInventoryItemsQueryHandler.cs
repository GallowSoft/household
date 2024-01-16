using MediatR;
using GallowSoft.Household.Infrastructure.Data;

namespace GallowSoft.Household.Application.InventoryItem;

public class GetInventoryItemsQueryHandler(IApplicationDbContext repository) : IRequestHandler<GetInventoryItemsQuery, IEnumerable<InventoryItemReadDto>>
{
    private readonly IApplicationDbContext _repository = repository;

    public async Task<IEnumerable<InventoryItemReadDto>> Handle(GetInventoryItemsQuery request, CancellationToken cancellationToken)
    {
        var inventoryItems = await _repository.GetInventoryItems(cancellationToken);
        return inventoryItems.Select(x => new InventoryItemReadDto
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            CreatedDate = x.CreatedDate,
            LastModifiedDate = x.UpdatedDate
        });
    }
}