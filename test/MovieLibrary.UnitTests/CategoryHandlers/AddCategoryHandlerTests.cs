using MediatR;
using Moq;
using MovieLibrary.Core.Exceptions;
using MovieLibrary.Core.Features.Commands;
using MovieLibrary.Core.Features.Handlers;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;
using MovieLibrary.UnitTests.Mocks;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.UnitTests.CategoryHandlers;

public class AddCategoryHandlerTests
{
    private Mock<IUnitOfWork> _mockUnitOfWork;

    [SetUp]
    public void SetUp()
    {
        _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
    }

    [TestCase("Comedy")]
    [TestCase("Horror")]
    [Test]
    public async Task AddCategoryTest_ValidCategoryName_CategoryAdded(string name)
    {
        var handler = new AddCategoryHandler(_mockUnitOfWork.Object);
        var result = await handler.Handle(new AddCategoryCommand(name), CancellationToken.None);
        var categories = new List<Category>(_mockUnitOfWork.Object.CategoryRepository.GetAllAsync().Result);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo(Unit.Value));
            Assert.That(categories, Has.Count.EqualTo(3));
        });
    }

    [TestCase("Action")]
    [Test]
    public void AddCategoryTest_CategoryNameExists_ThrowsCategoryException(string name)
    {
        var handler = new AddCategoryHandler(_mockUnitOfWork.Object);

        Assert.That(
            async () => await handler.Handle(new AddCategoryCommand(name), CancellationToken.None),
            Throws.TypeOf<CategoryException>()
        );
    }
}