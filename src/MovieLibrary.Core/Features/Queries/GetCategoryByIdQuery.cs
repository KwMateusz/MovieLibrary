using MediatR;
using MovieLibrary.Core.ViewModels;

namespace MovieLibrary.Core.Features.Queries;

public record GetCategoryByIdQuery(int CategoryId) : IRequest<CategoryViewModel>;