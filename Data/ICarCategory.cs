using CarRentalApi.Model;

namespace CarRentalApi.Data
{
    public interface ICarCategory
    {
        Task CreateAsync(CarCategory carCategory);
        Task DeleteAsync(int id);
        Task<IEnumerable<CarCategory>> GetAllAsync();
        Task<CarCategory> GetByIdAsync(int id);
        Task<IEnumerable<CarCategory>> GetSearchedAsync(string search);
        Task UpdateAsync(CarCategory carCategory);
    }
}