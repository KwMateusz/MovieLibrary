using MediatR;

namespace MovieLibrary.Core.Features.Commands;

public record RemoveCategoryCommand(int CategoryId) : IRequest;