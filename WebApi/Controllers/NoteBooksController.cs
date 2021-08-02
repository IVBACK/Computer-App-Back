using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using ComputerAPP.SERVICE.SqlRepos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ComputerAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class NoteBooksController : ControllerBase
    {
        private readonly SqlNotebookRepo sqlNoteBookRepo;

        public NoteBooksController(ComputerAppDBContext db)
        {
            sqlNoteBookRepo = new SqlNotebookRepo(db);
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<NoteBook> notebooks = sqlNoteBookRepo.GetAllNotebooks();
            if (notebooks != null)
                return Ok(notebooks);

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            NoteBook notebook = sqlNoteBookRepo.GetNotebookById(id);
            if (notebook != null)
                return Ok(notebook);

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody]NoteBook notebook)
        {
            if (sqlNoteBookRepo.CreateNotebook(notebook))
                return Ok(notebook);

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, NoteBook notebook)
        {
            if (sqlNoteBookRepo.UpdateNotebook(notebook))
                return Ok(notebook);

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (sqlNoteBookRepo.DeleteNotebook(id))
                return Ok();

            return NotFound();
        }
    }
}
