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
        public async Task<IEnumerable<User>> Get( string search)
        {
            
            return await userRepository.GetSearchedAsync(search);

        }
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task <ActionResult<User>> Get( int? id)
        { 
            if(id == null )
            {
                return NotFound();
            }
            return await userRepository.GetByIdAsync(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            await userRepository.AddAsync(user);
            return Ok();

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put( int id, [FromBody] User user )
        {
            if (id != user.UserId)
            {
                return NotFound();
            }
           await userRepository.UpdateAsync(user);
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            await userRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
