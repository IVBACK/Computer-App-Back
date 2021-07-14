using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using ComputerAPP.SERVICE;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ComputerAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteBooksController : ControllerBase
    {
        private readonly NoteBookService validation;

        public NoteBooksController(ComputerAppDbContext db)
        {
            validation = new NoteBookService(db);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return validation.GetNoteBooks();          
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return validation.GetNoteBookById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]NoteBook noteBook)
        {
            return validation.PostNoteBook(noteBook);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, NoteBook noteBook)
        {
            return validation.PutNoteBook(id, noteBook);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return validation.DeleteNoteBook(id);
        }
    }
}
