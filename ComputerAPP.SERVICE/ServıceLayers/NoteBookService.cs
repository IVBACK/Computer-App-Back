using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace ComputerAPP.SERVICE
{
    public class NoteBookService : ControllerBase
    {
        private readonly ComputerAppDbContext db;

        public NoteBookService(ComputerAppDbContext db)
        {
            this.db = db;
        }

        public IActionResult GetNoteBooks()
        {
            return Ok(db.NoteBooks.ToList());
        }

        public IActionResult GetNoteBookById(int id)
        {
            var noteBook = db.NoteBooks.Find(id);
            if (noteBook == null)
                return NotFound();

            return Ok(noteBook);
        }

        public IActionResult PostNoteBook(NoteBook noteBook)
        {
            try
            {
                db.NoteBooks.Add(noteBook);
                db.SaveChanges();
            }
            catch (System.Exception)
            {
                //Return Error 
                throw;
            }
                     
            return GetNoteBookById(noteBook.NoteBookId);
        }

        public IActionResult PutNoteBook(int id, NoteBook noteBook)
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

        public IActionResult DeleteNoteBook(int id)
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
