using MediatR;
using MovieLibrary.Core.ViewModels;

namespace MovieLibrary.Core.Features.Queries;

public class GetCategoryByIdQuery : IRequest<CategoryViewModel>
{
    public int CategoryId { get; set; }

    public GetCategoryByIdQuery(int categoryId)
    {
        CategoryId = categoryId;
    }
}