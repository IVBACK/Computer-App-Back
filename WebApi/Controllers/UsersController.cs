using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using ComputerAPP.SERVICE.SqlRepos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerAPP.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly SqlUserRepo sqlUserRepo;

        public UsersController(ComputerAppDBContext db)
        {
            sqlUserRepo = new SqlUserRepo(db);
        }

        [HttpGet]       
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<User> users = await sqlUserRepo.GetAllUsers();
            if (users != null)
                return Ok(users);

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            User user = await sqlUserRepo.GetUserById(id);
            if (user != null)
                return Ok(user);
            
            return NotFound();
        }

        [AllowAnonymous]
        [HttpPost("login")]      
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginRequest userLoginRequest)
        {       
            UserLoginResponse userLoginResponse = await sqlUserRepo.GetUserByMail(userLoginRequest);
            
            if (userLoginResponse != null)
            {               
                return Ok(userLoginResponse);
            }              

            return NotFound("Wrong Password Or Email");
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] User user)
        {
            if (!await sqlUserRepo.CheckUserWithEmail(user.Email))
                return BadRequest("Account With This Email Already Exists");

            if (await sqlUserRepo.CreateUser(user))
                return Ok(user);

            return BadRequest("Invalid Name Or Email");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(User user)
        {
            if(await sqlUserRepo.UpdateUser(user))
                return Ok(user);

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if(await sqlUserRepo.DeleteUser(id))
                return Ok();

            return NotFound();
        }
    }
}
