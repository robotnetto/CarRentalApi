using CarRentalApi.Model;

namespace CarRentalApi.Data
{
    public interface IBookingRepository
    {
        Task AddAsync(Booking booking);
        Task DeleteAsync(int id);
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<Booking> GetByIdAsync(int id);
        Task UpdateAsync(Booking booking);
    }
}