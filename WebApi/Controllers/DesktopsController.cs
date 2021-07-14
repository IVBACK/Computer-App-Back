using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using ComputerAPP.SERVICE.ValidationServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ComputerAPP.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DesktopsController : ControllerBase
    {
        private readonly DesktopService validation;

        public DesktopsController(ComputerAppDbContext db)
        {
            validation = new DesktopService(db);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return validation.GetDesktops();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return validation.GetDesktopById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Desktop desktop)
        {
            return validation.PostDesktop(desktop);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Desktop desktop)
        {
            return validation.PutDesktop(id, desktop);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return validation.DeleteDesktop(id);
        }
    }
}
