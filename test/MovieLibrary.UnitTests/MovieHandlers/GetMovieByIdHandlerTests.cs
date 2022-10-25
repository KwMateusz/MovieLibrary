using AutoMapper;
using Moq;
using MovieLibrary.AutoMapper.Api;
using MovieLibrary.Core.Features.Handlers;
using MovieLibrary.Core.Features.Queries;
using MovieLibrary.Core.ViewModels;
using MovieLibrary.Data;
using MovieLibrary.UnitTests.Mocks;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.UnitTests.MovieHandlers;

public class GetMovieByIdHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;

    public GetMovieByIdHandlerTests()
    {
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<AutoMapperProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [TestCase(1)]
    [Test]
    public async Task GetMovieByIdTest_ValidId_ReturnsRequestedMovie(int id)
    {
        var handler = new GetMovieByIdHandler(_mockUnitOfWork.Object, _mapper);
        var result = await handler.Handle(new GetMovieByIdQuery(id), CancellationToken.None);

        Assert.That(result, Is.TypeOf<MovieViewModel>());
        Assert.That(result.Title, Is.EqualTo("Harry Potter and the Sorcerer's Stone"));
    }

    [TestCase(-1)]
    [TestCase(0)]
    [Test]
    public async Task GetMovieByIdTest_InvalidId_ReturnsNull(int id)
    {
        var handler = new GetMovieByIdHandler(_mockUnitOfWork.Object, _mapper);
        var result = await handler.Handle(new GetMovieByIdQuery(id), CancellationToken.None);

        Assert.That(result, Is.Null);
    }
}