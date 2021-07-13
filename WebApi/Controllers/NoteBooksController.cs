using ComputerAPP.CORE.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComputerAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteBooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Reading NoteBooks");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Reading NoteBook #{id}");
        }

        [HttpPost]
        public IActionResult Post([FromBody]NoteBook noteBook)
        {
            return Ok(noteBook);
        }

        [HttpPut]
        public IActionResult Put([FromBody] NoteBook noteBook)
        {
            return Ok(noteBook);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Deleting NoteBook #{id}");
        }
    }
}
