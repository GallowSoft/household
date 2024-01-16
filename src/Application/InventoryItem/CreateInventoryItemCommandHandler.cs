using GallowSoft.Household.Infrastructure.Data;
using MediatR;

namespace GallowSoft.Household.Application.InventoryItem;

public class CreateInventoryItemCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateInventoryItemCommand, InventoryItemDto>
{
    public async Task<InventoryItemDto> HandleAsync(CreateInventoryItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.InventoryItem.InventoryItem
        {
            Name = request.Name,
            Description = request.Description,
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now
        };
    
        context.InventoryItems.Add(entity);
        await context.SaveChangesAsync(cancellationToken);

        return new InventoryItemDto
        {
            Name = entity.Name,
            Description = entity.Description,
        };
    }

    public Task<InventoryItemDto> Handle(CreateInventoryItemCommand request, CancellationToken cancellationToken)
    {
        return HandleAsync(request, cancellationToken);
    }
}