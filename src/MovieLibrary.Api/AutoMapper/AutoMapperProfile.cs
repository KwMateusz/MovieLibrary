using AutoMapper;
using MovieLibrary.Core.ViewModels;
using MovieLibrary.Data.Entities;
using System.Linq;

namespace MovieLibrary.AutoMapper.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Movie, MovieViewModel>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.MovieCategories.Select(mc => mc.Category).ToList()));

            CreateMap<Category, CategoryViewModel>();
        }
    }
}