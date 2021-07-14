using ComputerAPP.CORE.Models;
using ComputerAPP.DATA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ComputerAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteBooksController : ControllerBase
    {
        private readonly NoteBookDbContext db;

        public NoteBooksController(NoteBookDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.NoteBooks.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var noteBook = db.NoteBooks.Find(id);
            if (noteBook == null)
                return NotFound();

            return Ok(noteBook);
        }

        [HttpPost]
        public IActionResult Post([FromBody]NoteBook noteBook)
        {
            db.NoteBooks.Add(noteBook);
            db.SaveChanges();

            return CreatedAtAction(nameof(GetById),
                new { id = noteBook.NoteBookId },
                noteBook);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, NoteBook noteBook)
        {
            if (id != noteBook.NoteBookId) return BadRequest();

            db.Entry(noteBook).State = EntityState.Modified;
            
            try
            {
                db.SaveChanges();
            }
            catch (System.Exception)
            {
                if (db.NoteBooks.Find(id) == null)
                    return NotFound();
                throw;
            }
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var noteBook = db.NoteBooks.Find(id);
            if (noteBook == null)
                return NotFound();

            db.NoteBooks.Remove(noteBook);
            db.SaveChanges();

            return Ok(noteBook);
        }
    }
}
