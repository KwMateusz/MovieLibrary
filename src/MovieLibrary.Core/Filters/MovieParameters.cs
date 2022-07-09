using MovieLibrary.Data.Filters;
using System.Collections.Generic;

namespace MovieLibrary.Core.Filters
{
    public class MovieParameters : QueryStringParameters
    {
        public string Text { get; set; }
        public List<int> CategoriesId { get; set; }
        public decimal? MinImdb { get; set; }
        public decimal? MaxImdb { get; set; }
    }
}