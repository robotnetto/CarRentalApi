using System.ComponentModel.DataAnnotations;

namespace CarRentalApi.Model
{
    public class CarCategory
    {
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Name { get; set; } = "";
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
