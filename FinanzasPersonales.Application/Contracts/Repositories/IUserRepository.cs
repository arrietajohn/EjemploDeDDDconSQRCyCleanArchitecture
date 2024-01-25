using FinanzasPersonales.Domain.Entities;

namespace FinanzasPersonales.Application.Contracts.Repositories;

public interface  IUserRepository
{

    public Task<bool> SaveAsync(User user);
    public Task<bool> DeleteAsync(int id);
    public Task<bool> UpdateAsync(User user);
    public Task<User> GetByIdAsync(int id);
    public Task<IEnumerable<User>> GetAllAsync();
    public Task<IEnumerable<User>> GetByDescripcionAsync(string descripcion);
    public Task<User> GetByIdentificationAsync(int identificationNumber);
    public Task<User> GetByEmailAsync(int email);
    public Task<IEnumerable<User>> GetByFirstNameAsync(string firstName);
    public Task<IEnumerable<User>> GetByLastNameAsync(string lastName);
    public Task<IEnumerable<User>> GetByLastGenderAsync(string gender);
    public Task<IEnumerable<User>> GetByRoleAsync(string role);
    public Task<IEnumerable<User>> GetByBirthDateAsync(DateTime birthDate);
    public Task<IEnumerable<User>> GetByBirthDateBetweenAsync(DateTime date1, DateTime date2);
    public Task<IEnumerable<User>> GetByStateAsync(string state);
}
