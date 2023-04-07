using CarRentalApi.Model;

namespace CarRentalApi.Data
{
    public interface ICarRepository
    {
        Task CreateAsync(Car car);
        Task DeleteAsync(Car car);
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car> GetByIdAsync(int id);
        Task<IEnumerable<Car>> SearchCarAsync(string search);
        Task UpdateAsync(Car car);
    }
}