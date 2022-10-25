using MovieLibrary.Core.Repositories;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core;

public class UnitOfWork : IUnitOfWork
{
    private readonly MovieLibraryContext _context;
    private IRepository<Movie> _movieRepository;
    private IRepository<Category> _categoryRepository;
    private bool _disposed = false;

    public UnitOfWork(MovieLibraryContext movieLibraryContext)
    {
        _context = movieLibraryContext;
    }

    public IRepository<Movie> MovieRepository
    {
        get
        {
            return _movieRepository ??= new MovieRepository(_context);
        }
    }

    public IRepository<Category> CategoryRepository
    {
        get
        {
            return _categoryRepository ??= new CategoryRepository(_context);
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
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }
}