using MediatR;

namespace MovieLibrary.Core.Features.Commands
{
    public class AddCategoryCommand : IRequest
    {
        public string Name { get; set; }

        public AddCategoryCommand(string name)
        {
            Name = name;
        }
    }
}