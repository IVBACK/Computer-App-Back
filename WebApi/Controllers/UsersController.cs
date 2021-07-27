using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using ComputerAPP.SERVICE.SqlRepos;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(sqlUserRepo.GetAllUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(sqlUserRepo.GetUserById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (user.UserId != null)
            {
                return BadRequest();
            }
            else
            {
                sqlUserRepo.CreateUser(user);
                sqlUserRepo.SaveChanges();

                return Ok(user);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, User user)
        {
            if (id != user.UserId)
                return BadRequest();

            try
            {
                sqlUserRepo.UpdateUser(id, user);
            }
            catch (System.Exception)
            {
                if (sqlUserRepo.GetUserById(id) == null)
                    return NotFound();
                throw;
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = sqlUserRepo.GetUserById(id);
            if (user == null)
                return NotFound();

            sqlUserRepo.DeleteUser(id);
            sqlUserRepo.SaveChanges();

            return Ok();
        }
    }
}
