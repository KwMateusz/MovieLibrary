using MediatR;
using Moq;
using MovieLibrary.Core.Exceptions;
using MovieLibrary.Core.Features.Commands;
using MovieLibrary.Core.Features.Handlers;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;
using MovieLibrary.UnitTests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.UnitTests.CategoryHandlers
{
    public class RemoveCategoryHandlerTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;

        [SetUp]
        public void SetUp()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
        }

        [TestCase(2)]
        [Test]
        public async Task RemoveCategoryTest_ValidCategoryId_CategoryRemoved(int id)
        {
            var handler = new RemoveCategoryHandler(_mockUnitOfWork.Object);
            var result = await handler.Handle(new RemoveCategoryCommand(id), CancellationToken.None);
            var categories = new List<Category>(_mockUnitOfWork.Object.CategoryRepository.GetAllAsync().Result);
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(Unit.Value));
                Assert.That(categories, Has.Count.EqualTo(1));
            });
        }

        [TestCase(30)]
        [Test]
        public void RemoveCategoryTest_InvalidId_ThrowsCategoryException(int id)
        {
            var handler = new RemoveCategoryHandler(_mockUnitOfWork.Object);

            Assert.That(
                async () => await handler.Handle(new RemoveCategoryCommand(id), CancellationToken.None),
                Throws.TypeOf<CategoryException>()
            );
        }
    }
}
