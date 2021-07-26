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
            return Ok(sqlNoteBookRepo.GetAllProducts());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(sqlNoteBookRepo.GetProductById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]NoteBook noteBook)
        {
            if(noteBook.NoteBookId != null)
            {
                return BadRequest();
            }
            else
            {
                sqlNoteBookRepo.CreateProduct(noteBook);
                sqlNoteBookRepo.SaveChanges();

                return Ok(noteBook);
            }         
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, NoteBook noteBook)
        {
            if (id != noteBook.NoteBookId)
                return BadRequest();

            try
            {
                sqlNoteBookRepo.UpdateProduct(id, noteBook);
            }
            catch (System.Exception)
            {
                if (sqlNoteBookRepo.GetProductById(id) == null)
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var noteBook = sqlNoteBookRepo.GetProductById(id);
            if (noteBook == null)
                return NotFound();

            sqlNoteBookRepo.DeleteProduct(id);
            sqlNoteBookRepo.SaveChanges();

            return Ok();
        }
    }
}
