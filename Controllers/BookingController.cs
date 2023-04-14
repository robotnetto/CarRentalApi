using CarRentalApi.Data;
using CarRentalApi.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRentalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository bookingRepository;

        public BookingController(IBookingRepository bookingRepository) 
        {
            this.bookingRepository = bookingRepository;
        }
        // GET: api/<BookingController>
        [HttpGet]
        public async Task<IEnumerable<Booking>> Get()
        {
            return await bookingRepository.GetAllAsync();
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> Get(int id)
        {
            if (id == null)
            {
                return NotFound();  
            }
            return await bookingRepository.GetByIdAsync(id);
        }

        // POST api/<BookingController>
        [HttpPost]
        public async Task<ActionResult<User>> Post(Booking booking)
        {
            await bookingRepository.AddAsync(booking);
            return Ok();
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Booking>> Put(int id, [FromBody] Booking booking)
        {
            if (id != booking.Id)
            {
                return BadRequest();
            }
            await bookingRepository.UpdateAsync(booking);
            return Ok();
        }
             

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Booking>> Delete(int id)
        {
            await bookingRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
