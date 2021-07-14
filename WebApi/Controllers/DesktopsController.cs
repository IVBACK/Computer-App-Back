using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ComputerAPP.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DesktopsController : ControllerBase
    {
        private readonly ComputerAppDbContext db;

        public DesktopsController(ComputerAppDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Desktops.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var noteBook = db.Desktops.Find(id);
            if (noteBook == null)
                return NotFound();

            return Ok(noteBook);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Desktop desktop)
        {
            db.Desktops.Add(desktop);
            db.SaveChanges();

            return CreatedAtAction(nameof(GetById),
                new { id = desktop.DesktopId },
                desktop);
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
                if (db.Desktops.Find(id) == null)
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var desktop = db.Desktops.Find(id);
            if (desktop == null)
                return NotFound();

            db.Desktops.Remove(desktop);
            db.SaveChanges();

            return Ok(desktop);
        }
    }
}
