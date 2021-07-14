using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using ComputerAPP.SERVICE;
using Microsoft.AspNetCore.Mvc;


namespace ComputerAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteBooksController : ControllerBase
    {
        private readonly SqlNoteBookRepo sqlNoteBookRepo;

        public NoteBooksController(ComputerAppDBContext db)
        {
            sqlNoteBookRepo = new SqlNoteBookRepo(db);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(sqlNoteBookRepo.GetAllNoteBooks());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(sqlNoteBookRepo.GetNoteBookById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]NoteBook noteBook)
        {
            sqlNoteBookRepo.CreateNoteBook(noteBook);
            sqlNoteBookRepo.SaveChanges();

            return Ok(noteBook);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, NoteBook noteBook)
        {
            if (id != noteBook.NoteBookId)
                return BadRequest();

            try
            {
                sqlNoteBookRepo.UpdateNoteBook(id, noteBook);
            }
            catch (System.Exception)
            {
                if (sqlNoteBookRepo.GetNoteBookById(id) == null)
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var noteBook = sqlNoteBookRepo.GetNoteBookById(id);
            if (noteBook == null)
                return NotFound();

            sqlNoteBookRepo.DeleteNoteBook(id);
            sqlNoteBookRepo.SaveChanges();

            return Ok();
        }
    }
}
