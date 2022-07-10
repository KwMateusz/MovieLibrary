using AutoMapper;
using Moq;
using MovieLibrary.AutoMapper.Api;
using MovieLibrary.Core.Features.Handlers;
using MovieLibrary.Core.Features.Queries;
using MovieLibrary.Core.ViewModels;
using MovieLibrary.Data;
using MovieLibrary.UnitTests.Mocks;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.UnitTests.CategoryHandlers
{
    public class GetCategoryByIdHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public GetCategoryByIdHandlerTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<AutoMapperProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [TestCase(1)]
        [Test]
        public async Task GetCategoryByIdTest_ValidId_ReturnsRequestedCategory(int id)
        {
            var handler = new GetCategoryByIdHandler(_mockUnitOfWork.Object, _mapper);
            var result = await handler.Handle(new GetCategoryByIdQuery(id), CancellationToken.None);

            Assert.That(result, Is.TypeOf<CategoryViewModel>());
            Assert.That(result.Name, Is.EqualTo("Action"));
        }

        [TestCase(-1)]
        [TestCase(0)]
        [Test]
        public async Task GetCategoryByIdTest_InvalidId_ReturnsNull(int id)
        {
            var handler = new GetCategoryByIdHandler(_mockUnitOfWork.Object, _mapper);
            var result = await handler.Handle(new GetCategoryByIdQuery(id), CancellationToken.None);

            Assert.That(result, Is.Null);
        }
    }
}