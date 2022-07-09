using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieLibrary.Data.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<ICollection<Movie>> FilterAsync(QueryStringParameters parameters);
    }
}