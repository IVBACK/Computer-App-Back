using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAPP.SERVICE.ValidationServices
{
    public class DesktopService : ControllerBase
    {
        private readonly ComputerAppDbContext db;

        public DesktopService(ComputerAppDbContext db)
        {
            this.db = db;
        }

        public IActionResult GetDesktops()
        {
            return Ok(db.Desktops.ToList());
        }

        public IActionResult GetDesktopById(int id)
        {
            var desktop = db.Desktops.Find(id);
            if (desktop == null)
                return NotFound();

            return Ok(desktop);
        }

        public IActionResult PostDesktop(Desktop desktop)
        {
            try
            {
                db.Desktops.Add(desktop);
                db.SaveChanges();
            }
            catch (System.Exception)
            {
                //Return Error 
                throw;
            }

            return GetDesktopById(desktop.DesktopId);
        }

        public IActionResult PutDesktop(int id, Desktop desktop)
        {
            if (id != desktop.DesktopId) return BadRequest();

            db.Entry(desktop).State = EntityState.Modified;

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

        public IActionResult DeleteDesktop(int id)
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
