using MediatR;
using MovieLibrary.Core.Features.Commands;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Features.Handlers
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryCommand>
    {
        private IUnitOfWork _unitOfWork;

        public AddCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.CategoryRepository.AddAsync(new Category
            {
                Name = request.Name
            });

            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}