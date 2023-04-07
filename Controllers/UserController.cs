using CarRentalApi.Data;
using CarRentalApi.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRentalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository) 
        {
            this.userRepository = userRepository;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await userRepository.GetAllAsync();
        }
        // GET: api/<UserController>
        [HttpGet("search")]
        public async Task<IEnumerable<User>> Get([FromQuery] string search)
        {
            
             return await userRepository.GetSearchedAsync(search);
            
        }
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            return await userRepository.GetByIdAsync(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task Post(User user)
        {
            await userRepository.AddAsync(user);
            return;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put( int id,  User user )
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }
            await userRepository.UpdateAsync(user);
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await userRepository.DeleteAsync(id);
        }
    }
}
