using MediatR;

namespace MovieLibrary.Core.Features.Commands;

public record AddCategoryCommand(string Name) : IRequest;