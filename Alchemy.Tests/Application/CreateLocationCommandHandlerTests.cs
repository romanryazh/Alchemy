using Alchemy.Application.Common.Exceptions;
using Alchemy.Application.Locations.Commands.CreateLocation;
using Alchemy.Domain.Entities;
using Alchemy.Domain.Interfaces;
using AutoFixture;
using Moq;

namespace Alchemy.Tests.Application;

public class CreateLocationCommandHandlerTests
{
    private readonly Fixture _fixture;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    private readonly Mock<ILocationRepository> _locationRepositoryMock;

    private readonly Mock<IUniqueCheckerService> _uniqueCheckerServiceMock;
    private readonly CreateLocationCommandHandler _handler;

    public CreateLocationCommandHandlerTests()
    {
        _fixture = new Fixture();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _locationRepositoryMock = new Mock<ILocationRepository>();
        _uniqueCheckerServiceMock = new Mock<IUniqueCheckerService>();

        _unitOfWorkMock
            .Setup(uow => uow.LocationRepository)
            .Returns(_locationRepositoryMock.Object);

        _handler = new CreateLocationCommandHandler(_unitOfWorkMock.Object, _uniqueCheckerServiceMock.Object);
    }

    [Fact]
    public async Task Handle_ValidCommand_CreatesAndSavesLocation()
    {
        var command = _fixture.Create<CreateLocationCommand>();
        _uniqueCheckerServiceMock.Setup(checker =>
            checker
                .IsUniqueAsync<Location>("Name", command.Name, CancellationToken.None)).ReturnsAsync(true);

        var result = await _handler.Handle(command, CancellationToken.None);

        _locationRepositoryMock.Verify(repo =>
            repo.AddAsync(It.IsAny<Location>(), It.IsAny<CancellationToken>()), Times.Once);
        _unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        Assert.NotEqual(Guid.Empty, result);
    }

    // [Fact]
    // public async Task Handle_SaveChangesThrows_ThrowsException()
    // {
    //     // Arrange
    //     var command = _fixture.Create<CreateLocationCommand>();
    //
    //     _unitOfWorkMock.Setup(uow =>
    //         uow.SaveChangesAsync(It.IsAny<CancellationToken>())).ThrowsAsync(new ConflictException("ащибка"));
    //
    //     _locationRepositoryMock.Verify(repo => 
    //         repo.AddAsync(It.IsAny<Location>(), It.IsAny<CancellationToken>()), Times.Once);
    //     // Act и Assert
    //     await Assert.ThrowsAsync<ConflictException>(() => _handler.Handle(command, CancellationToken.None));
    //
    // }

}