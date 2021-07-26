using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using ComputerAPP.SERVICE.ValidationServices;
using Microsoft.AspNetCore.Mvc;

namespace ComputerAPP.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DesktopsController : ControllerBase
    {
        private readonly SqlDesktopRepo sqlDesktopRepo;

        public DesktopsController(ComputerAppDBContext db)
        {
            sqlDesktopRepo = new SqlDesktopRepo(db);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(sqlDesktopRepo.GetAllProducts());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(sqlDesktopRepo.GetProductById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Desktop desktop)
        {
            if(desktop.DesktopId != null)
            {
                return BadRequest();
            }
            else
            {
                sqlDesktopRepo.CreateProduct(desktop);
                sqlDesktopRepo.SaveChanges();

                return Ok(desktop);
            }           
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Desktop desktop)
        {
            if (id != desktop.DesktopId)
                return BadRequest();

            try
            {
                sqlDesktopRepo.UpdateProduct(id, desktop);
            }
            catch (System.Exception)
            {
                if (sqlDesktopRepo.GetProductById(id) == null)
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var desktop = sqlDesktopRepo.GetProductById(id);
            if (desktop == null)
                return NotFound();

            sqlDesktopRepo.DeleteProduct(id);
            sqlDesktopRepo.SaveChanges();

            return Ok();
        }
    }
}
