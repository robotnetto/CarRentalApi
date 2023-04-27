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
    public class CarCategoryController : ControllerBase
    {
        private readonly ICarCategory carCategoryRepository;

        public CarCategoryController (ICarCategory carCategoryRepository)
        {
            this.carCategoryRepository = carCategoryRepository;
        }
        // GET: api/<CarCategoryController>
        [HttpGet]
        public async Task<IEnumerable<CarCategory>> Get()
        {
            return await carCategoryRepository.GetAllAsync();
        }
        [HttpGet("search")]
        public async Task<IEnumerable<CarCategory>> Get(string search)
        {
            return await carCategoryRepository.GetSearchedAsync(search);
        }
        // GET api/<CarCategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarCategory>> Get( int id)
        {
            if (id == null ) 
            {
                return NotFound();
            }
            return await carCategoryRepository.GetByIdAsync(id);
        }

        // POST api/<CarCategoryController>
        [HttpPost]
        public async Task<ActionResult<CarCategory>> Post(CarCategory carCategory)
        {
            await carCategoryRepository.CreateAsync(carCategory);
            return Ok();
        }

        // PUT api/<CarCategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CarCategory>> Put(int id, [FromBody] CarCategory carCategory)
        {
            if (id != carCategory.Id)
            {
                return NotFound();
            }
            await carCategoryRepository.UpdateAsync(carCategory);
            return Ok();
        }

        // DELETE api/<CarCategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarCategory>> Delete(int id)
        {
            await carCategoryRepository.DeleteAsync(id);
            return Ok();    
        }
    }
}
