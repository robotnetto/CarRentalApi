using CarRentalApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApi.Data
{
    public class CarRepository : ICarRepository
    {
        private readonly ApiContext apiContext;

        public CarRepository(ApiContext apiContext ) 
        {
            this.apiContext = apiContext;
        }
        public async Task CreateAsync(Car car)
        {
            apiContext.Cars.Add(car);
            await apiContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var carId = await GetByIdAsync(id);
            if (carId != null)
            {
                 apiContext.Cars.Remove(carId);
                 await apiContext.SaveChangesAsync();

            }
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await apiContext.Cars.OrderBy(c => c.CarId).ToListAsync();
        }

        public async Task<Car> GetByIdAsync(int? id)
        {
            return await apiContext.Cars.FirstOrDefaultAsync(c => c.CarId == id);
        }

        public async Task UpdateAsync(Car car)
        {
            apiContext.Update(car);
            await apiContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Car>> SearchCarAsync(string search)
        {
            return await apiContext.Cars.Where
                (c => c.Model.Contains(search) || c.Brand.Contains(search)).ToListAsync();
        }
    }
}
