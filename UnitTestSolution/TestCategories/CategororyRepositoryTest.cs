using FinanzasPersonales.Application.Contracts.Repositories.Writer;
using FinanzasPersonales.Domain.Entities;
using FinanzasPersonales.Persistence.Database;
using FinanzasPersonales.Persistence.Repositories.Writers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace UnitTestSolution.TestCategories;

[TestClass]
public class CategororyRepositoryTest
{


    private EfDatabeseContext GetDbContextInMemory(int versionDb)
    {
        var option = new DbContextOptionsBuilder<EfDatabeseContext>()
            // dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 7.0.15
            .UseInMemoryDatabase("FinanzasPersonalesDbTest"+ versionDb)
            .Options;
        return  new EfDatabeseContext(option);
    }



    [TestMethod]
    public async Task Test1_SaveAsync_WhenCalled_ShoulldSaveCategoryEntity()
    {
        // Arrange
        var category = new Category { Name = "Vestuario", Description = "para verse bien" };
        var ilogger = new Mock<ILogger<CategoryWriteRepository>>().Object;
        var dbContext = GetDbContextInMemory(1);
        var categoryWriteRepositoy = new CategoryWriteRepository(dbContext, ilogger);
        // Act
        await categoryWriteRepositoy.SaveAsync(category);
        // Assert
        Assert.IsTrue(category.Id == 1);
    }


    [TestMethod]
    public async Task Test2_UpdateAsync_WhenCalled_ShoulldUpdateCategoryEntity()
    {
        // Arrange
        var dbContext = GetDbContextInMemory(2);
        var logger = new Mock<ILogger<CategoryWriteRepository>>().Object;
        var categoryWriteRepository = new CategoryWriteRepository(dbContext, logger);
        var category = new Category { Name = "Vestuario", Description = "para verse bien" };
        var name = category.Name;
        await categoryWriteRepository.SaveAsync(category);
        category.Name = "Vestiario 2";
        // Act
        await categoryWriteRepository.UpdateAsync(category);
        var categoryInDb = await dbContext.Categories.FindAsync(category.Id);
        // Assert
        Assert.IsFalse(categoryInDb.Name.Equals(name));
    }

    [TestMethod]
    public async Task Test3_DeleteAsync_WnenCalled_ShouldDeleteCategoryEntity()
    {
        // Arrange
        var dbContext = GetDbContextInMemory(3);
        var logger = new Mock<ILogger<CategoryWriteRepository>>().Object;
        var categoryWriteRepository = new CategoryWriteRepository(dbContext, logger);
        var category = new Category { Name = "Vestuario", Description = "para verse bien" };
        await categoryWriteRepository.SaveAsync(category);
        // Act
        await categoryWriteRepository.DeleteAsync(category);
        // Assert
        var categoryTotal = dbContext.Categories.ToList().Count;
        Assert.IsTrue(categoryTotal == 0);


    }

    [TestMethod]
    public async Task Test3_DeleteByIdAsync_WhenCalled_ShouldDeleteEntityIfExists()
    {
        // Arrange
        var dbContext = GetDbContextInMemory(4);
        var logger = new Mock<ILogger<CategoryWriteRepository>>().Object;
        Category category = new Category { Name = "Categoria 1", Description = "Descipcion -1 " };
        var categoryWriteRepository = new CategoryWriteRepository(dbContext, logger);
        categoryWriteRepository.SaveAsync(category);
        // Act
        categoryWriteRepository.DeleteByIdAsync(category.Id);
        var total = dbContext.Categories.ToList().Count;
        // Assert
        Assert.IsTrue(total == 0);

    }

    [TestMethod]
    public async Task Test5_SaveAMasiveAsync_WhenCalled_ShouldInsertEntities()
    {
        // Arrange
        var dbContext = GetDbContextInMemory(5);
        var logger = new Mock<ILogger<CategoryWriteRepository>>().Object;
        var categoryWriteRepository = new CategoryWriteRepository(dbContext, logger);
        var categoryList = new List<Category> { 
                                                new Category { Name = "Categoria 1", Description = "Descripcion 1" } 
                                                , new Category { Name = "Categoria 2", Description = "Descripcion 2" }
                                                , new Category { Name = "Categoria 3", Description = "Descripcion 3" }
                                                , new Category { Name = "Categoria 4", Description = "Descripcion 4" }
                                                , new Category { Name = "Categoria 5", Description = "Descripcion 6" }
                                                };

        // Act
        categoryWriteRepository.SaveMassiveAsync(categoryList);
        var total = dbContext.Categories.ToList().Count;

        // Assert
        Assert.IsTrue (total == 5); 

    }

    [TestMethod]
    public async Task Test6_UpdateAMasiveAsync_WhenCalled_ShouldUpdateEntities()
    {
        // Arrange
        var dbContext = GetDbContextInMemory(5);
        var logger = new Mock<ILogger<CategoryWriteRepository>>().Object;
        var categoryWriteRepository = new CategoryWriteRepository(dbContext, logger);
        var categoryList = dbContext.Categories.ToList();
        foreach (var category in categoryList)
        {
            category.Name = "Categoria " + (categoryList.IndexOf(category) + 20);
        }
        // Act
        categoryWriteRepository.UpdateMassiveAsync(categoryList);
        categoryList = dbContext.Categories.ToList();

        // Assert
        Assert.IsTrue(categoryList.FirstOrDefault().Name.Equals("Categoria 20"));

    }


    [TestMethod]
    public async Task Test7_UpdateAMasiveAsync_WhenCalled_ShouldIDeleteEntities()
    {
        // Arrange
        var dbContext = GetDbContextInMemory(5);
        var logger = new Mock<ILogger<CategoryWriteRepository>>().Object;
        var categoryWriteRepository = new CategoryWriteRepository(dbContext, logger);
        var categoryList = dbContext.Categories.ToList();
       
        // Act
        categoryWriteRepository.DeleteMassiveAsync(categoryList);
        categoryList = dbContext.Categories.ToList();

        // Assert
        Assert.IsTrue(categoryList.Count == 0);

    }

}