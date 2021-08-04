using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using ComputerAPP.SERVICE.SqlRepos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerAPP.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DesktopsController : ControllerBase
    {
        private readonly SqlProductRepo<Desktop> sqlDesktopRepo;

        public DesktopsController(ComputerAppDBContext db)
        {
            sqlDesktopRepo = new SqlProductRepo<Desktop>(db);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<Desktop> desktops = await sqlDesktopRepo.GetAllProducts();
            if (desktops != null)
                return Ok(desktops);

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            Desktop desktop = await sqlDesktopRepo.GetProductById(id);
            if (desktop != null)
                return Ok(desktop);

            return NotFound();            
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Desktop desktop)
        {
            if (await sqlDesktopRepo.CreateProduct(desktop))
                return Ok(desktop);

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, Desktop desktop)
        {
            if (await sqlDesktopRepo.UpdateProduct(desktop))
                return Ok(desktop);

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (await sqlDesktopRepo.DeleteProduct(id))
                return Ok();

            return NotFound();
        }
    }
}
