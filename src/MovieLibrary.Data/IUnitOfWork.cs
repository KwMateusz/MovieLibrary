using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Data
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Movie> MovieRepository { get; }
        public IRepository<Category> CategoryRepository { get; }
        Task<int> SaveAsync(CancellationToken cancellationToken);
    }
}