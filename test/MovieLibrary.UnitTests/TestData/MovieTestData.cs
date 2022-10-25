using MovieLibrary.Data.Entities;
using System.Collections.Generic;

namespace MovieLibrary.UnitTests.TestData;

internal static class MovieTestData
{
    public static List<Movie> GetMoviesTestData()
    {
        return new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Title = "Harry Potter and the Sorcerer's Stone",
                Description = "An orphaned boy enrolls in a school of wizardry...",
                Year = 2001,
                ImdbRating = 7.6M,
                MovieCategories = new List<MovieCategory>
                {
                    new MovieCategory()
                    {
                        Id = 1,
                        MovieId = 1,
                        CategoryId = 2,
                        Category = new Category()
                        {
                            Id = 2,
                            Name = "Adventure",
                            MovieCategories = new List<MovieCategory>()
                        }
                    },
                    new MovieCategory()
                    {
                        Id = 2,
                        MovieId = 1,
                        CategoryId = 6,
                        Category = new Category()
                        {
                            Id = 6,
                            Name = "Family",
                            MovieCategories = new List<MovieCategory>()
                        }
                    },
                    new MovieCategory()
                    {
                        Id = 3,
                        MovieId = 1,
                        CategoryId = 7,
                        Category = new Category()
                        {
                            Id = 7,
                            Name = "Fantasy",
                            MovieCategories = new List<MovieCategory>()
                        }
                    }
                }
            },
            new Movie
            {
                Id = 2,
                Title = "Harry Potter and the Chamber of Secrets",
                Description = "An ancient prophecy seems to be coming true...",
                Year = 2002,
                ImdbRating = 6.8M,
                MovieCategories = new List<MovieCategory>
                {
                    new MovieCategory()
                    {
                        Id = 4,
                        MovieId = 2,
                        CategoryId = 2,
                        Category = new Category()
                        {
                            Id = 2,
                            Name = "Adventure",
                            MovieCategories = new List<MovieCategory>()
                        }
                    },
                    new MovieCategory()
                    {
                        Id = 5,
                        MovieId = 2,
                        CategoryId = 6,
                        Category = new Category()
                        {
                            Id = 6,
                            Name = "Family",
                            MovieCategories = new List<MovieCategory>()
                        }
                    },
                    new MovieCategory()
                    {
                        Id = 6,
                        MovieId = 2,
                        CategoryId = 7,
                        Category = new Category()
                        {
                            Id = 7,
                            Name = "Fantasy",
                            MovieCategories = new List<MovieCategory>()
                        }
                    }
                }
            },
            new Movie
            {
                Id = 3,
                Title = "Forrest Gump",
                Description = "The presidencies of Kennedy and Johnson...",
                Year = 1994,
                ImdbRating = 8.9M,
                MovieCategories = new List<MovieCategory>
                {
                    new MovieCategory()
                    {
                        Id = 7,
                        MovieId = 3,
                        CategoryId = 5,
                        Category = new Category()
                        {
                            Id = 5,
                            Name = "Drama",
                            MovieCategories = new List<MovieCategory>()
                        }
                    },
                    new MovieCategory()
                    {
                        Id = 8,
                        MovieId = 3,
                        CategoryId = 8,
                        Category = new Category()
                        {
                            Id = 8,
                            Name = "Romance",
                            MovieCategories = new List<MovieCategory>()
                        }
                    }
                }
            }
        };
    }
}