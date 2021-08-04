using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using ComputerAPP.SERVICE.SqlRepos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NoteBooksController : ControllerBase
    {
        private readonly SqlProductRepo<NoteBook> sqlNoteBookRepo;

        public NoteBooksController(ComputerAppDBContext db)
        {
            sqlNoteBookRepo = new SqlProductRepo<NoteBook>(db);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<NoteBook> notebooks = await sqlNoteBookRepo.GetAllProducts();
            if (notebooks != null)
                return Ok(notebooks);

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            NoteBook notebook = await sqlNoteBookRepo.GetProductById(id);
            if (notebook != null)
                return Ok(notebook);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]NoteBook notebook)
        {
            if (await sqlNoteBookRepo.CreateProduct(notebook))
                return Ok(notebook);

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, NoteBook notebook)
        {
            if (await sqlNoteBookRepo.UpdateProduct(notebook))
                return Ok(notebook);

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (await sqlNoteBookRepo.DeleteProduct(id))
                return Ok();

            return NotFound();
        }
    }
}
