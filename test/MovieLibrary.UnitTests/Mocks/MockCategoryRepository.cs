using Moq;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Repositories;
using MovieLibrary.UnitTests.TestData;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieLibrary.UnitTests.Mocks;

public static class MockCategoryRepository
{
    public static Mock<ICategoryRepository> GetCategoryRepository()
    {
        var categories = CategoryTestData.GetCategoryTestData();

        var mockRepository = new Mock<ICategoryRepository>();

        mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(categories);
        mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) => categories.Find(x => x.Id == id));

        mockRepository.Setup(x => x.AddAsync(It.IsAny<Category>())).Returns((Category category) =>
        {
            categories.Add(category);
            return Task.FromResult(categories);
        });

        mockRepository.Setup(x => x.FindAsync(It.IsAny<Expression<Func<Category, bool>>>()))
            .ReturnsAsync((Expression<Func<Category, bool>> predicate) => categories.Where(predicate.Compile()));

        mockRepository.Setup(x => x.UpdateAsync(It.IsAny<Category>())).Returns((Category category) =>
        {
            var categoryToUpdate = categories.First(x => x.Id == category.Id);
            categoryToUpdate.Name = category.Name;
            return Task.FromResult(categories);
        });

        mockRepository.Setup(x => x.RemoveAsync(It.IsAny<Category>())).Returns((Category category) =>
        {
            categories.Remove(category);
            return Task.FromResult(categories);
        });

        return mockRepository;
    }
}