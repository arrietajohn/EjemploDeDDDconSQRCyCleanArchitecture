using FinanzasPersonales.Application.Contracts.Repositories;
using FinanzasPersonales.Domain.Entities;
using FinanzasPersonales.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinanzasPersonales.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{

    private readonly EfDatabeseContext _efDatabeseContext;

    // Esta Interface ya está disponible como base en .net Core 6+
    // CLI: dotnet add package Microsoft.Extensions.Logging.Abstractions
    // Registar la dependencia en el servicio de contenedor de dependencias del Mainser
    // services.AddScoped<ICategoryRepository, CategoryRepository>();
    // services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
    private readonly ILogger<CategoryRepository> _logger;

    public CategoryRepository(EfDatabeseContext efDatabeseContext, ILogger<CategoryRepository> logger)
    {
        _efDatabeseContext = efDatabeseContext ?? throw new ArgumentNullException(nameof(efDatabeseContext));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        var result = await _efDatabeseContext.Categories.ToListAsync();
        _logger.LogInformation($"Categorias: {result.Count()}");
        return result;
    }

    public async Task<IEnumerable<Category>> GetByDescription(string description)
    {
        var result = await _efDatabeseContext.Categories.Where(c => (c.Description ?? "").Contains(description)).ToListAsync();
        _logger.LogInformation($"Categorias: {result.Count()} que contienen {description} en la descripcion");
        return result;
    }

    public async Task<IEnumerable<Category>> GetByName(string name)
    {
        var result = await _efDatabeseContext.Categories.Where(c => c.Name.Contains(name)).ToListAsync();
        _logger.LogInformation($"Categorias: {result.Count()} que contienen {name} en la descripcion");
        return result;
    }

    public async Task<bool> DeleteAsync(Category category)
    {
        // using Microsoft.EntityFrameworkCore para EntityState;
        _efDatabeseContext.Entry(category).State = EntityState.Deleted;
        var result = await _efDatabeseContext.SaveChangesAsync();
        if (result > 0)
        {
            _logger.LogInformation($"Eliminada la instancia {nameof(category)} con ID: {category.Id}");
            return true;
        }
        else
        {
            _logger.LogInformation($"No fue Eliminada la instancia {nameof(category)} con ID: {category.Id}");
            return false;
        }
    }

    public async Task<bool> DeleteAsync(int categoryId)
    {
        var category = new Category { Id = categoryId };
        _efDatabeseContext.Entry(category).State = EntityState.Deleted;
        var result = await _efDatabeseContext.SaveChangesAsync();
        if (result > 0)
        {
            _logger.LogInformation($"Eliminada la instancia {nameof(category)} con ID: {category.Id}");
            return true;
        }
        else
        {
            _logger.LogInformation($"No fue Eliminada la instancia {nameof(category)} con ID: {category.Id}");
            return false;
        }
    }
    public async Task<bool> SaveAsync(Category category)
    {
        try
        {
            _efDatabeseContext.Categories.Add(category);
            await _efDatabeseContext.SaveChangesAsync();
            _logger.LogInformation($"Insertada la instancia {nameof(category)} con ID: {category.Id}");
            return true;
        }
        catch (DbUpdateException ex)
        {
            _logger.LogInformation($"No fue insertada la instancia {nameof(category)}, el ID: {category.Id} ya existe");
            _logger.LogInformation($"ERROR: {ex.Message}");
            return false;
        }

    }

    public async Task<bool> UpdateAsync(Category category)
    {
        var result = await _efDatabeseContext.Categories.FindAsync(category.Id);
        if (result != null)
        {
            _efDatabeseContext.Update(category);
            _logger.LogInformation($"Actuializada la instancia {nameof(category)} con ID: {category.Id}");
            await _efDatabeseContext.SaveChangesAsync();
            return true;
        }
        else
        {
            _logger.LogInformation($"Instancia {nameof(category)} no actualizada,  ID: {category.Id} no exite");
            return false;
        }
    }

    public async Task<Category> GetByid(int id)
    {
        return await _efDatabeseContext.Categories.FindAsync(id);
    }
}





/*
 // ------ Opcion 1 ---------------------

dbContext.Categories.Add(newCategory);
await dbContext.SaveChangesAsync();

// ------ Opcion 2 ---------------------



dbContext.Add(newCategory);
await dbContext.SaveChangesAsync();


// ------ Opcion 3 ---------------------
  
 otras forma de guardar
try{
    dbContext.Categories.Add(newCategory);
    await dbContext.SaveChangesAsync();
}
catch(DbUpdateException ex)
{
    if (ex.InnerException is SqlException sqlException)
    {
        // Buscar el código de violación de llave primaria del motor Bd suyastante.
        if (sqlException.Number == 2627 || sqlException.Number == 2601)
        {
            // El número 2627 y 2601 son códigos de error específicos para violaciones de clave primaria
            //...
        }
    }
}



// ------ Opcion 4 ---------------------

dbContext.Categories.AddRange(newCategories);
await dbContext.SaveChangesAsync();
 
// ---------------------

dbContext.Categories.AddRange(newCategory1, newCategory2, newCategory3);
await dbContext.SaveChangesAsync();


// ------ Opcion 5 ---------------------

dbContext.Categories.Attach(newCategory); // Adjunta la entidad como no modificada
dbContext.Entry(newCategory).State = EntityState.Added; // Cambia el estado a Added
await dbContext.SaveChangesAsync();

// ----------------------------

dbContext.Entry(newCategory).State = EntityState.Added;
await dbContext.SaveChangesAsync();



// ------ Opcion 6 ---------------------

var existingCategory = await dbContext.Categories.FindAsync(categoryId);
if (existingCategory == null)
{
    dbContext.Categories.Add(newCategory);
    await dbContext.SaveChangesAsync();
}


// ------ Opcion 7 ---------------------
try
{
    dbContext.Categories.Add(newCategory);
    await dbContext.SaveChangesAsync();
}
catch (DbUpdateException ex)
{
    // Manejar excepciones específicas relacionadas con la base de datos
}

// --------------- Opcion 8  ------------------------------

var newCategory = new Category { Name = "Nuevo Categoría", Description = "Descripción" };
dbContext.Entry(newCategory).State = EntityState.Added;
await dbContext.SaveChangesAsync();

// ------------------------------------------

FORMAS DE ACTUALIZAR
****************************
*
------------------ FORMA  ----------------------------------

var existingCategory = await dbContext.Categories.FindAsync(categoryId);

if (existingCategory != null)
{
    existingCategory.Name = "Nuevo Nombre";
    existingCategory.Description = "Nueva Descripción";
    
    await dbContext.SaveChangesAsync();
}


------------------            --------------------------

var existingCategory = await dbContext.Categories.FindAsync(categoryId);

if (existingCategory != null)
{
    existingCategory.Name = "Nuevo Nombre";
    existingCategory.Description = "Nueva Descripción";
    
    dbContext.Categories.Update(existingCategory);
    await dbContext.SaveChangesAsync();
}

// --------------------    -----------------------------

var detachedCategory = new Category { Id = categoryId, Name = "Nuevo Nombre", Description = "Nueva Descripción" };

dbContext.Categories.Attach(detachedCategory);
dbContext.Entry(detachedCategory).State = EntityState.Modified;
await dbContext.SaveChangesAsync();

// ---------------------- --------------------------

dbContext.Entry(parentEntity).State = EntityState.Modified;
await dbContext.SaveChangesAsync();


// ------------------- ---------------------------------

var existingCategory = await dbContext.Categories.FindAsync(categoryId);

if (existingCategory != null)
{
    existingCategory.Name = "Nuevo Nombre";
    existingCategory.Description = "Nueva Descripción";
    
    dbContext.Entry(existingCategory).State = EntityState.Modified;
    await dbContext.SaveChangesAsync();
}


 */