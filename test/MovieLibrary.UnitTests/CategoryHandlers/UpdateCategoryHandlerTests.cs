using MediatR;
using Moq;
using MovieLibrary.Core.Exceptions;
using MovieLibrary.Core.Features.Commands;
using MovieLibrary.Core.Features.Handlers;
using MovieLibrary.Data;
using MovieLibrary.UnitTests.Mocks;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.UnitTests.CategoryHandlers
{
    public class UpdateCategoryHandlerTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;

        [SetUp]
        public void SetUp()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
        }

        [TestCase(1, "Comedy")]
        [TestCase(2, "Comedy")]
        [Test]
        public async Task UpdateCategoryTest_ValidCategoryId_CategoryUpdated(int id, string name)
        {
            var handler = new UpdateCategoryHandler(_mockUnitOfWork.Object);
            var result = await handler.Handle(new UpdateCategoryCommand(id, name), CancellationToken.None);
            var category = _mockUnitOfWork.Object.CategoryRepository.GetByIdAsync(id).Result;

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(Unit.Value));
                Assert.That(category.Name, Is.EqualTo(name));
            });
        }

        [TestCase(33, "Comedy")]
        [Test]
        public void UpdateCategoryTest_InvalidCategoryId__ThrowsCategoryException(int id, string name)
        {
            var handler = new UpdateCategoryHandler(_mockUnitOfWork.Object);

            Assert.That(
                async () => await handler.Handle(new UpdateCategoryCommand(id, name), CancellationToken.None),
                Throws.TypeOf<CategoryException>()
            );
        }

        [TestCase(2, "Action")]
        [Test]
        public void UpdateCategoryTest_CategoryAlreadyExists__ThrowsCategoryException(int id, string name)
        {
            var handler = new UpdateCategoryHandler(_mockUnitOfWork.Object);

            Assert.That(
                async () => await handler.Handle(new UpdateCategoryCommand(id, name), CancellationToken.None),
                Throws.TypeOf<CategoryException>()
            );
        }
    }
}