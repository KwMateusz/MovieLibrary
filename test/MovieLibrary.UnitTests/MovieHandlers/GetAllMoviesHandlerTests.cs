using AutoMapper;
using Moq;
using MovieLibrary.AutoMapper.Api;
using MovieLibrary.Core.Features.Handlers;
using MovieLibrary.Core.Features.Queries;
using MovieLibrary.Core.ViewModels;
using MovieLibrary.Data;
using MovieLibrary.UnitTests.Mocks;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.UnitTests.MovieHandlers
{
    public class GetAllMoviesHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public GetAllMoviesHandlerTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<AutoMapperProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Test]
        public async Task GetAllMoviesTest_Default_ReturnsCollectionOfMovies()
        {
            var handler = new GetAllMoviesHandler(_mockUnitOfWork.Object, _mapper);
            var result = await handler.Handle(new GetAllMoviesQuery(), CancellationToken.None);

            Assert.That(result, Is.InstanceOf<IEnumerable<MovieViewModel>>());
        }
    }
}