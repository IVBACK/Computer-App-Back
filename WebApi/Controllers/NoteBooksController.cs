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
        private readonly NoteBookService notebookService;

        public NoteBooksController(ComputerAppDbContext db)
        {
            notebookService = new NoteBookService(db);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return notebookService.GetNoteBooks();          
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return notebookService.GetNoteBookById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]NoteBook noteBook)
        {
            return notebookService.PostNoteBook(noteBook);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, NoteBook noteBook)
        {
            return notebookService.PutNoteBook(id, noteBook);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return notebookService.DeleteNoteBook(id);
        }
    }
}
