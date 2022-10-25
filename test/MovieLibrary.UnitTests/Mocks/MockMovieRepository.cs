using Moq;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Repositories;
using MovieLibrary.UnitTests.TestData;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieLibrary.UnitTests.Mocks;

public static class MockMovieRepository
{
    public static Mock<IMovieRepository> GetMovieRepository()
    {
        var movies = MovieTestData.GetMoviesTestData();

        var mockRepository = new Mock<IMovieRepository>();

        mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(movies);
        mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) => movies.Find(x => x.Id == id));

        mockRepository.Setup(x => x.AddAsync(It.IsAny<Movie>())).Returns((Movie movie) =>
        {
            movies.Add(movie);
            return Task.FromResult(movies);
        });

        mockRepository.Setup(x => x.FindAsync(It.IsAny<Expression<Func<Movie, bool>>>()))
            .ReturnsAsync((Expression<Func<Movie, bool>> predicate) => movies.Where(predicate.Compile()));

        mockRepository.Setup(x => x.UpdateAsync(It.IsAny<Movie>())).Returns((Movie movie) =>
        {
            var movieToUpdate = movies.First(x => x.Id == movie.Id);
            movieToUpdate.Title = movie.Title;
            return Task.FromResult(movies);
        });

        mockRepository.Setup(x => x.RemoveAsync(It.IsAny<Movie>())).Returns((Movie movie) =>
        {
            movies.Remove(movie);
            return Task.FromResult(movies);
        });

        return mockRepository;
    }
}