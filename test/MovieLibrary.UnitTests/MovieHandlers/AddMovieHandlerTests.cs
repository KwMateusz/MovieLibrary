using MediatR;
using Moq;
using MovieLibrary.Core.Exceptions;
using MovieLibrary.Core.Features.Commands;
using MovieLibrary.Core.Features.Handlers;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;
using MovieLibrary.UnitTests.Mocks;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.UnitTests.MovieHandlers;

public class AddMovieHandlerTests
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

    [TestCase("The Matrix")]
    [TestCase("La vita è bella")]
    [Test]
    public async Task AddMovieTest_ValidMovieName_MovieAdded(string title)
    {
        var handler = new AddMovieHandler(_mockUnitOfWork.Object);
        var result = await handler.Handle(new AddMovieCommand(title, Description, Year, ImdbRating), CancellationToken.None);
        var movies = new List<Movie>(_mockUnitOfWork.Object.MovieRepository.GetAllAsync().Result);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo(Unit.Value));
            Assert.That(movies, Has.Count.EqualTo(4));
        });
    }

    [TestCase("Harry Potter and the Sorcerer's Stone")]
    [Test]
    public void AddMovieTest_MovieNameExists_ThrowsMovieException(string title)
    {
        var handler = new AddMovieHandler(_mockUnitOfWork.Object);

        Assert.That(
            async () => await handler.Handle(new AddMovieCommand(title, Description, Year, ImdbRating), CancellationToken.None),
            Throws.TypeOf<MovieException>()
        );
    }
}