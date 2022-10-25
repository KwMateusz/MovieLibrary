using MediatR;
using Moq;
using MovieLibrary.Core.Exceptions;
using MovieLibrary.Core.Features.Commands;
using MovieLibrary.Core.Features.Handlers;
using MovieLibrary.Data;
using MovieLibrary.UnitTests.Mocks;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.UnitTests.MovieHandlers;

public class UpdateMovieHandlerTests
{
    private const string Description = "When a beautiful stranger leads computer...";
    private const int Year = 1999;
    private const decimal ImdbRating = 8.7M;
    private Mock<IUnitOfWork> _mockUnitOfWork;

    [SetUp]
    public void SetUp()
    {
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
    }

    [TestCase(1, "Whiplash")]
    [TestCase(2, "Intouchables")]
    [Test]
    public async Task UpdateMovieTest_ValidMovieId_MovieUpdated(int id, string title)
    {
        var handler = new UpdateMovieHandler(_mockUnitOfWork.Object);
        var result = await handler.Handle(new UpdateMovieCommand(id, title, Description, Year, ImdbRating), CancellationToken.None);
        var movie = _mockUnitOfWork.Object.MovieRepository.GetByIdAsync(id).Result;

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo(Unit.Value));
            Assert.That(movie.Title, Is.EqualTo(title));
        });
    }

    [TestCase(33, "Joker")]
    [Test]
    public void UpdateMovieTest_InvalidMovieId_ThrowsMovieException(int id, string title)
    {
        var handler = new UpdateMovieHandler(_mockUnitOfWork.Object);

        Assert.That(
            async () => await handler.Handle(new UpdateMovieCommand(id, title, Description, Year, ImdbRating), CancellationToken.None),
            Throws.TypeOf<MovieException>()
        );
    }

    [TestCase(3, "Harry Potter and the Sorcerer's Stone")]
    [Test]
    public void UpdateMovieTest_MovieAlreadyExists_ThrowsMovieException(int id, string title)
    {
        var handler = new UpdateMovieHandler(_mockUnitOfWork.Object);

        Assert.That(
            async () => await handler.Handle(new UpdateMovieCommand(id, title, Description, Year, ImdbRating), CancellationToken.None),
            Throws.TypeOf<MovieException>()
        );
    }
}