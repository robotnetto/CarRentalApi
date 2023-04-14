using CarRentalApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApi.Data
{
    public class ApiContext : DbContext

    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) {} 
        
        public DbSet<Car> Cars { get; set; } 
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Model.CarCategory> Categories { get; set; }
        public DbSet<User> Users { get; set; }
      
    }
}
