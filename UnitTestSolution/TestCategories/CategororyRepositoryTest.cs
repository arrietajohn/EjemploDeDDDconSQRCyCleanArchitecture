using FinanzasPersonales.Application.Contracts.Repositories;
using FinanzasPersonales.Domain.Entities;
using FinanzasPersonales.Persistence.Database;
using FinanzasPersonales.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace UnitTestSolution.TestCategories
{
    [TestClass]
    public class CategororyRepositoryTest
    {

        private readonly EfDatabeseContext _dbContext;
        private readonly ILogger<CategoryRepository> _logger;
        private readonly ICategoryRepository _categoryRepository;

        public CategororyRepositoryTest()
        {
            var option = new DbContextOptionsBuilder<EfDatabeseContext>()
                // dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 7.0.15
                .UseInMemoryDatabase("AppFinanzasPersonalesDb2Test")
                .Options;
            _dbContext = new EfDatabeseContext(option);
            // dotnet add package Moq --version 4.20.70
            _logger = new Mock<ILogger<CategoryRepository>>().Object;

            _categoryRepository = new CategoryRepository(_dbContext, _logger);

        }



        [TestMethod]
        public async Task Test1_SaveAsync_And_GetByid_ReturnBollean_WhenNewCategoryIsValid()
        {
            var category = new Category { Name = "Vestuario", Description = "para verse bien" };
            var result = await _categoryRepository.SaveAsync(category);
            Assert.IsTrue(result);
            var newCategoty = await _categoryRepository.GetByid(category.Id);
            Assert.AreEqual(category, newCategoty);
        }


        [TestMethod]
        public async Task Test2_GetAll_ReturnListCategoria_WhenCategoriesExist()
        {
            var categoriesList = await _categoryRepository.GetAll();
            Assert.IsNotNull(categoriesList);
            foreach (var category in categoriesList)
            {
                Console.WriteLine(category.Name);
            }

        }

        [TestMethod]
        public async Task Test3_GetByid_ReturnCategory_WhereCategoryExists()
        {
            var result = await _categoryRepository.GetByid(1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Test4_UpdateAsyn_ReturnBoolean_WhenCategoryExists()
        {
            var category = await _categoryRepository.GetByid(1);
            Assert.IsNotNull(category);
            var oldDesc = category.Description;
            var newDesc = category.Description + " - Modificada";
            category.Description = newDesc;
            var result = await _categoryRepository.UpdateAsync(category);
            Assert.IsTrue(result);
            var categotyUpdate = await _categoryRepository.GetByid(1);
            Assert.AreNotEqual(oldDesc, categotyUpdate.Description);
        }

        [TestMethod]
        public async Task Test5_DeleteByid_ReturnTrue_WhenCategoryExist()
        {
            var result = await _categoryRepository.DeleteAsync(1);
            Assert.IsTrue(result);
        }


    }
}