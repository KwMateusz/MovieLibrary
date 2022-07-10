using MediatR;
using MovieLibrary.Core.Exceptions;
using MovieLibrary.Core.Features.Commands;
using MovieLibrary.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Features.Handlers
{
    public class RemoveCategoryHandler : IRequestHandler<RemoveCategoryCommand>
    {
        private IUnitOfWork _unitOfWork;

        public RemoveCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId);

            if (category == null)
                throw new CategoryException($"Category wtih id {request.CategoryId} does not exist.");

            await _unitOfWork.CategoryRepository.RemoveAsync(category);
            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}