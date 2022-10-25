using AutoMapper;
using MediatR;
using MovieLibrary.Core.Features.Queries;
using MovieLibrary.Core.ViewModels;
using MovieLibrary.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Features.Handlers;

public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdQuery, MovieViewModel>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public GetMovieByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<MovieViewModel> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<MovieViewModel>(await _unitOfWork.MovieRepository.GetByIdAsync(request.MovieId));
    }
}