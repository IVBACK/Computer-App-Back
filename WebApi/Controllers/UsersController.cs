using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using ComputerAPP.SERVICE.SqlRepos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ComputerAPP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class UsersController : ControllerBase
    {
        private readonly SqlUserRepo sqlUserRepo;

        public UsersController(ComputerAppDBContext db)
        {
            sqlUserRepo = new SqlUserRepo(db);
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<User> users = sqlUserRepo.GetAllUsers();
            if (users != null)
                return Ok(users);

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            User user = sqlUserRepo.GetUserById(id);
            if (user != null)
                return Ok(user);
            
            return NotFound();
        }

        [HttpPost("{login}")]
        public IActionResult Login([FromBody] UserLoginRequest userLoginRequest)
        {          
            UserLoginResponse userLoginResponse = sqlUserRepo.GetUserByMail(userLoginRequest);
            
            if (userLoginResponse != null)
                return Ok(userLoginResponse);

            return NotFound("Wrong Password Or Email");
        }

        [HttpPost]
        public IActionResult Register([FromBody] User user)
        {
            if (!sqlUserRepo.CheckEmailExists(user.Mail))
                return BadRequest("Account With This Email Already Exists");

            if (sqlUserRepo.CreateUser(user))
                return Ok(user);

            return BadRequest("Invalid Name Or Email");
        }

        [HttpPut("{id}")]
        public IActionResult Put(User user)
        {
            if(sqlUserRepo.UpdateUser(user))
                return Ok(user);

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(sqlUserRepo.DeleteUser(id))
                return Ok();

            return NotFound();
        }
    }
}
