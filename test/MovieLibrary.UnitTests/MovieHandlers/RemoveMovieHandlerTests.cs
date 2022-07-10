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

namespace MovieLibrary.UnitTests.MovieHandlers
{
    public class RemoveMovieHandlerTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;

        [SetUp]
        public void SetUp()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
        }

        [TestCase(2)]
        [Test]
        public async Task RemoveMovieTest_ValidMovieId_MovieRemoved(int id)
        {
            var handler = new RemoveMovieHandler(_mockUnitOfWork.Object);
            var result = await handler.Handle(new RemoveMovieCommand(id), CancellationToken.None);
            var movies = new List<Movie>(_mockUnitOfWork.Object.MovieRepository.GetAllAsync().Result);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(Unit.Value));
                Assert.That(movies, Has.Count.EqualTo(2));
            });
        }

        [TestCase(30)]
        [Test]
        public void RemoveMovieTest_InvalidId_ThrowsMovieException(int id)
        {
            var handler = new RemoveMovieHandler(_mockUnitOfWork.Object);

            Assert.That(
                async () => await handler.Handle(new RemoveMovieCommand(id), CancellationToken.None),
                Throws.TypeOf<MovieException>()
            );
        }
    }
}