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
        public IActionResult Post([FromBody]NoteBook notebook)
        {
            if(notebook.NoteBookId != null)
            {
                return BadRequest();
            }
            else
            {
                sqlNoteBookRepo.CreateProduct(notebook);
                sqlNoteBookRepo.SaveChanges();

                return Ok(notebook);
            }         
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, NoteBook notebook)
        {
            if (id != notebook.NoteBookId)
                return BadRequest();

            try
            {
                sqlNoteBookRepo.UpdateProduct(id, notebook);
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
            var notebook = sqlNoteBookRepo.GetProductById(id);
            if (notebook == null)
                return NotFound();

            sqlNoteBookRepo.DeleteProduct(id);
            sqlNoteBookRepo.SaveChanges();

            return Ok();
        }
    }
}
