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
            return Ok(sqlDesktopRepo.GetAllDesktops());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(sqlDesktopRepo.GetDesktopById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Desktop desktop)
        {
            sqlDesktopRepo.CreateDesktop(desktop);
            sqlDesktopRepo.SaveChanges();

            return Ok(desktop);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Desktop desktop)
        {
            if (id != desktop.DesktopId)
                return BadRequest();

            try
            {
                sqlDesktopRepo.UpdateDesktop(id, desktop);
            }
            catch (System.Exception)
            {
                if (sqlDesktopRepo.GetDesktopById(id) == null)
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var desktop = sqlDesktopRepo.GetDesktopById(id);
            if (desktop == null)
                return NotFound();

            sqlDesktopRepo.DeleteDesktop(id);
            sqlDesktopRepo.SaveChanges();

            return Ok();
        }
    }
}
