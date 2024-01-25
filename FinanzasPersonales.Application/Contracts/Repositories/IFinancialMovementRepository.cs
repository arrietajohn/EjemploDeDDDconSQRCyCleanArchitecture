using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories;

public interface IFinancialMovementRepository
{
    public Task<bool> SaveAsync(FinancialMovement financialMovement);
    public Task<bool> DeleteAsync(int id);
    public Task<bool> UpdateAsync(FinancialMovement financialMovement);
    public Task<FinancialMovement> GetByIdAsync(int id);
    public Task<IEnumerable<FinancialMovement>> GetAllAsync();
    public Task<IEnumerable<FinancialMovement>> GetByValueAsync( decimal value);
    public Task<IEnumerable<FinancialMovement>> GetByValueBetweenAsync( decimal value1, decimal value2);
    public Task<IEnumerable<FinancialMovement>> GetMinValueAsync( );
    public Task<IEnumerable<FinancialMovement>> GetMaxValueAsync( );
    public Task<IEnumerable<FinancialMovement>> GetByDateAsync(DateTime fecha );
    public Task<IEnumerable<FinancialMovement>> GetByDateBetwennAsync(DateTime fecha1, DateTime fecha2 );
    public Task<IEnumerable<FinancialMovement>> GetByNameAsync(string name);
    public Task<IEnumerable<FinancialMovement>> GetByDescriptionAsync(string description);
    public Task<IEnumerable<FinancialMovement>> GetByUserAsync(User user);
    public Task<IEnumerable<FinancialMovement>> GetByUserAsync(int userId);
    
}
