using System.Collections.Generic;

namespace MovieLibrary.Core.ViewModels;

public class MovieViewModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int Year { get; set; }

    public decimal ImdbRating { get; set; }

    public ICollection<CategoryViewModel> Categories { get; set; }
}