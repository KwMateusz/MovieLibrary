using Moq;
using MovieLibrary.Core.Repositories;
using MovieLibrary.Data;

namespace MovieLibrary.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockCategoryRepository = MockCategoryRepository.GetCategoryRepository();
            var mockMovieRepository = MockMovieRepository.GetMovieRepository();

            mockUnitOfWork.Setup(x => x.CategoryRepository).Returns(mockCategoryRepository.Object);
            mockUnitOfWork.Setup(x => x.MovieRepository).Returns(mockMovieRepository.Object);

            return mockUnitOfWork;
        }
    }
}