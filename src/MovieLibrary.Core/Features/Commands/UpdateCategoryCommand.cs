using MediatR;

namespace MovieLibrary.Core.Features.Commands;

public record UpdateCategoryCommand(int CategoryId, string Name) : IRequest;