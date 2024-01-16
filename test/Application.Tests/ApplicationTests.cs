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

}