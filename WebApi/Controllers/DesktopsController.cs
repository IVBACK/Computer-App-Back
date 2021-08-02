using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using ComputerAPP.SERVICE.SqlRepos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            IEnumerable<Desktop> desktops = sqlDesktopRepo.GetAllDesktops();
            if (desktops != null)
                return Ok(desktops);

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Desktop desktop = sqlDesktopRepo.GetDesktopById(id);
            if (desktop != null)
                return Ok(desktop);

            return NotFound();            
        }

        [HttpPost]
        public IActionResult Post([FromBody] Desktop desktop)
        {
            if (sqlDesktopRepo.CreateDesktop(desktop))
                return Ok(desktop);

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Desktop desktop)
        {
            if (sqlDesktopRepo.UpdateDesktop(desktop))
                return Ok(desktop);

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (sqlDesktopRepo.DeleteDesktop(id))
                return Ok();

            return NotFound();
        }
    }
}
