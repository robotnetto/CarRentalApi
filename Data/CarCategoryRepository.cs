using CarRentalApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApi.Data
{
    public class CarCategoryRepository : ICarCategory
    {
        private readonly ApiContext context;

        public CarCategoryRepository(ApiContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(CarCategory carCategory)
        {
            context.Categories.Add(carCategory);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var carCategoryiId = await GetByIdAsync(id);
            if (carCategoryiId != null)
            {
                context.Categories.Remove(carCategoryiId);
                await context.SaveChangesAsync();
            }
            
        }

        public async Task<IEnumerable<CarCategory>> GetAllAsync()
        {
            return await context.Categories.OrderBy(c => c.Id).ToListAsync();
        }
        public async Task<IEnumerable<CarCategory>> GetSearchedAsync(string search)
        {
            return await context.Categories.Where(c => c.Name.Contains(search)).OrderBy(c => c.Id).ToListAsync();
        }

        public async Task<CarCategory> GetByIdAsync(int id)
        {
            return await context.Categories.Include(c => c.Cars).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(CarCategory carCategory)
        {
            context.Categories.Update(carCategory);
            await context.SaveChangesAsync();
        }
    }
}
