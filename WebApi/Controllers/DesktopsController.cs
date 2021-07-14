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
        private readonly DesktopService desktopService;

        public DesktopsController(ComputerAppDbContext db)
        {
            desktopService = new DesktopService(db);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return desktopService.GetDesktops();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return desktopService.GetDesktopById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Desktop desktop)
        {
            return desktopService.PostDesktop(desktop);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Desktop desktop)
        {
            return desktopService.PutDesktop(id, desktop);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return desktopService.DeleteDesktop(id);
        }
    }
}
