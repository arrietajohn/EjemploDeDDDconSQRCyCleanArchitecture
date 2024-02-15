using FinanzasPersonales.Domain.Entities;
using FinanzasPersonales.Persistence.Database;
using FinanzasPersonales.Persistence.Repositories.Readers;
using FinanzasPersonales.Persistence.Repositories.Writers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;


namespace FinanzasPersonales.UnitTest.TestCategories;

[TestClass]
public class CategoryReadRepositoryTest
{
    [TestMethod]    
    public async Task Test1_FindAllAsync_WhenCalled_ReturnCategoriesList()
    {
        // Arange
        var logger = new Mock<ILogger<CategoryReadRepository>>().Object;
        var dbContext = GetDbContext(10);
        var categoryReadRespositry = new CategoryReadRepository(dbContext, logger);
        var categoryList = new List<Category> {
                                                new Category { Name = "Categoria 1", Description = "Descripcion 1" }
                                                , new Category { Name = "Categoria 2", Description = "Descripcion 2" }
                                                , new Category { Name = "Categoria 3", Description = "Descripcion 3" }
                                                , new Category { Name = "Categoria 4", Description = "Descripcion 4" }
                                                , new Category { Name = "Categoria 5", Description = "Descripcion 6" }
                                                };

        var logger2 = new Mock<ILogger<CategoryWriteRepository>>().Object;
        var categoryWriteRepository = new CategoryWriteRepository(dbContext, logger2);
        await  categoryWriteRepository.SaveMassiveAsync(categoryList);
        // Act
        var listCategoriesInDb = await categoryReadRespositry.FindAllAsync();
        // Assert
        Assert.IsTrue(listCategoriesInDb.ToList().Count == categoryList.Count);
    }

    public EfDatabeseContext GetDbContext(int version)
    {
        var options = new DbContextOptionsBuilder<EfDatabeseContext>()
            .UseInMemoryDatabase("FinanzasPersonalesDbTest" + version)
            .Options;
        return new EfDatabeseContext(options);  
    }


    
}

