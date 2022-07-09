using MediatR;

namespace MovieLibrary.Core.Features.Commands
{
    public class UpdateCategoryCommand : IRequest
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public UpdateCategoryCommand(int categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }
    }
}