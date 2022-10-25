using Microsoft.EntityFrameworkCore;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(MovieLibraryContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await ((MovieLibraryContext)_context).Categories.Include(x => x.MovieCategories).ToListAsync();
    }
}