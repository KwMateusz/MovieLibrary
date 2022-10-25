using MovieLibrary.Data.Entities;
using System.Collections.Generic;

namespace MovieLibrary.UnitTests.TestData;

internal static class CategoryTestData
{
    public static List<Category> GetCategoryTestData()
    {
        return new List<Category>
        {
            new Category
            {
                Id = 1,
                Name= "Action",
                MovieCategories = new List<MovieCategory>()
            },
            new Category
            {
                Id = 2,
                Name= "Adventure",
                MovieCategories = new List<MovieCategory>()
            }
        };
    }
}