using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerAPP.SERVICE.ValidationServices
{
    public class SqlDesktopRepo : IDesktopRepo
    {
        private readonly ComputerAppDBContext db_Context;

        public SqlDesktopRepo(ComputerAppDBContext db)
        {
            this.db_Context = db;
        }

        public void CreateDesktop(Desktop desktop)
        {
            db_Context.Desktops.Add(desktop);
        }

        public void DeleteDesktop(int id)
        {
            var desktop = db_Context.Desktops.Find(id);
            if (desktop == null)
            {
                throw new ArgumentNullException(nameof(desktop));
            }
            db_Context.Desktops.Remove(desktop);
        }

        public Desktop GetDesktopById(int id)
        {
            return db_Context.Desktops.FirstOrDefault(p => p.DesktopId == id);
        }

        public IEnumerable<Desktop> GetAllDesktops()
        {
            return db_Context.Desktops.ToList();
        }

        public void SaveChanges()
        {
            db_Context.SaveChanges();
        }

        public void UpdateDesktop(int id, Desktop desktop)
        {
            db_Context.Entry(desktop).State = EntityState.Modified;
            SaveChanges();
        }
    }
}
