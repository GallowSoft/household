using GallowSoft.Household.Application.InventoryItem;
using GallowSoft.Household.Domain.InventoryItem;
using GallowSoft.Household.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Application.Tests;

public class ApplicationTests
{
    [Fact]
    public async Task Handle_Should_Create_InventoryItem()
    {
        // Arrange
        var request = new CreateInventoryItemCommand
        {
            Name = "Test Item",
            Description = "Test Description"
        };

        var cancellationToken = new CancellationToken();

        var contextMock = new Mock<IApplicationDbContext>();
        contextMock.SetupGet(c => c.InventoryItems).Returns(new Mock<DbSet<InventoryItem>>().Object);

        var handler = new CreateInventoryItemCommandHandler(contextMock.Object);

        // Act
        var result = await handler.HandleAsync(request, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(request.Name, result.Name);
        Assert.Equal(request.Description, result.Description);
        contextMock.Verify(c => c.SaveChangesAsync(cancellationToken), Times.Once);
    }

    [Fact]
    public async Task Handle_ReturnsInventoryItems()
    {
        // Arrange
        var repository = new Mock<IApplicationDbContext>();
        var handler = new GetInventoryItemsQueryHandler(repository.Object);
        var query = new GetInventoryItemsQuery();
        var cancellationToken = new CancellationToken();

        var inventoryItems = new List<InventoryItem>
        {
            new() { Id = Guid.NewGuid(), Name = "Item 1", Description = "Description 1", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now},
            new() { Id = Guid.NewGuid(), Name = "Item 2", Description = "Description 2", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now},
            new() { Id = Guid.NewGuid(), Name = "Item 3", Description = "Description 3", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now}
        };

        repository.Setup(r => r.GetInventoryItems(cancellationToken)).ReturnsAsync(inventoryItems);

        // Act
        var result = await handler.Handle(query, cancellationToken);

        // Assert
        Assert.Equal(3, result.Count());

        var firstItem = result.First();
        Assert.Equal("Item 1", firstItem.Name);
        Assert.Equal("Description 1", firstItem.Description);
    }

}