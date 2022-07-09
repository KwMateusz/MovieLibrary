using Microsoft.EntityFrameworkCore;
using MovieLibrary.Core.Filters;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Filters;
using MovieLibrary.Data.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieLibraryContext context) : base(context)
        {
        }

        public async Task<ICollection<Movie>> FilterAsync(QueryStringParameters parameters)
        {
            var movieParameters = (MovieParameters)parameters;
            var movies = ((MovieLibraryContext)_context).Movies.Include(x => x.MovieCategories).ThenInclude(mc => mc.Category).AsQueryable();

            if (!string.IsNullOrEmpty(movieParameters.Text))
                movies = movies.Where(m => m.Title.ToLower().Contains(movieParameters.Text.ToLower()));
            if (movieParameters.CategoriesId != null && movieParameters.CategoriesId.Count != 0)
                movies = movies.Where(x => x.MovieCategories.Any(m => movieParameters.CategoriesId.Contains(m.Category.Id)));
            if (movieParameters.MinImdb.HasValue)
                movies = movies.Where(m => m.ImdbRating > movieParameters.MinImdb.Value);
            if (movieParameters.MaxImdb.HasValue)
                movies = movies.Where(m => m.ImdbRating < movieParameters.MaxImdb.Value);

            movies = movies.OrderByDescending(m => (double)m.ImdbRating);

            return await PagedList<Movie>.ToPagedListAsync(movies, movieParameters.PageNumber, movieParameters.PageSize);
        }

        public override async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await ((MovieLibraryContext)_context).Movies.Include(x => x.MovieCategories).ThenInclude(mc => mc.Category).ToListAsync();
        }

        public override async Task<Movie> GetByIdAsync(int movieId)
        {
            return await ((MovieLibraryContext)_context).Movies.Include(x => x.MovieCategories).ThenInclude(mc => mc.Category).FirstAsync(c => c.Id == movieId);
        }
    }
}