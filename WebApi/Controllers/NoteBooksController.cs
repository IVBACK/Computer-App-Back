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
        private readonly SqlNotebookRepo sqlNoteBookRepo;

        public NoteBooksController(ComputerAppDBContext db)
        {
            sqlNoteBookRepo = new SqlNotebookRepo(db);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<Notebook> notebooks = await sqlNoteBookRepo.GetAllNotebooks();
            if (notebooks != null)
                return Ok(notebooks);

            return NotFound();
        }

        [HttpPost("search")]
        public IActionResult GetNotebooksBySearch([FromBody] string search)
        {
            IEnumerable<Notebook> notebooksFiltered = sqlNoteBookRepo.SearchNotebooks(search);
            if (notebooksFiltered != null)
                return Ok(notebooksFiltered);

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            Notebook notebook = await sqlNoteBookRepo.GetNotebookById(id);
            if (notebook != null)
                return Ok(notebook);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Notebook notebook)
        {
            if (await sqlNoteBookRepo.AddNotebook(notebook))
                return Ok(notebook);

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, Notebook notebook)
        {
            if (await sqlNoteBookRepo.UpdateNotebook(notebook))
                return Ok(notebook);

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (await sqlNoteBookRepo.DeleteNotebook(id))
                return Ok();

            return NotFound();
        }
    }
}
