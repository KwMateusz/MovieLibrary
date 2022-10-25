using MediatR;
using MovieLibrary.Core.ViewModels;
using System.Collections.Generic;

namespace MovieLibrary.Core.Features.Queries;

public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryViewModel>>
{
}