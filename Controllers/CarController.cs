using CarRentalApi.Data;
using CarRentalApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRentalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository carRepository;

        public CarController(ICarRepository carRepository) 
        {
            this.carRepository = carRepository;
        }

        // GET: api/<CarController>
        [HttpGet]
        public async Task<IEnumerable<Car>> Get()
        {
            return await carRepository.GetAllAsync();
        }
        [HttpGet("search")]
        public async Task<IEnumerable<Car>> Get(string search)
        {
            return await carRepository.SearchCarAsync(search);
        }
        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return await carRepository.GetByIdAsync(id);    
        }

        // POST api/<CarController>
        [HttpPost]
        public async Task<ActionResult<Car>> Post(Car car)
        {
            await carRepository.CreateAsync(car);
            return Ok();
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Car>> Put(int id, [FromBody] Car car)
        {
           
            if (id != car.CarId)
            {
                return NotFound();
            }
            await carRepository.UpdateAsync(car);
            return Ok();        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> Delete(int id)
        {
            await carRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
