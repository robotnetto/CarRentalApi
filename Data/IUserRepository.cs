using CarRentalApi.Model;

namespace CarRentalApi.Data
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task DeleteAsync(int? id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int? id);
        Task<IEnumerable<User>> GetSearchedAsync(string search);
        Task UpdateAsync(User user);
    }
}