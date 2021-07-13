using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComputersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {

            return Ok("Reading Computers");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Reading Computer #{id}");
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
            return Ok($"Deleting Computer #{id}");
        }
    }
}
