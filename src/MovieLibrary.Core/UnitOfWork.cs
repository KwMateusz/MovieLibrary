using MovieLibrary.Core.Repositories;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private MovieLibraryContext _context;
        private IRepository<Movie> _movieRepository;
        private IRepository<Category> _categoryRepository;
        private IRepository<MovieCategory> _movieCategoryRepository;
        private bool _disposed = false;

        public UnitOfWork(MovieLibraryContext movieLibraryContext)
        {
            _context = movieLibraryContext;
        }

        public IRepository<Movie> MovieRepository
        {
            get
            {
                if (this._movieRepository == null)
                {
                    this._movieRepository = new MovieRepository(_context);
                }
                return _movieRepository;
            }
        }

        public IRepository<Category> CategoryRepository
        {
            get
            {
                if (this._categoryRepository == null)
                {
                    this._categoryRepository = new CategoryRepository(_context);
                }
                return _categoryRepository;
            }
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
    }
}