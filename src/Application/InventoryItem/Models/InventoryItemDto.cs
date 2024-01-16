namespace GallowSoft.Household.Application.InventoryItem;

public record InventoryItemCreateDto
{
    public required string Name { get; init; }
    public required string Description { get; init; }
}

public record InventoryItemReadDto
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required DateTime CreatedDate { get; init; }
    public required DateTime LastModifiedDate { get; init; }
}