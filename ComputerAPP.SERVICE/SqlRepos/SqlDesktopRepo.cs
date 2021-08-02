using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using ComputerAPP.SERVICE.IRepos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerAPP.SERVICE.SqlRepos
{   
    public class SqlDesktopRepo : IDesktopRepo
    {
        private readonly ComputerAppDBContext db_Context;

        public SqlDesktopRepo(ComputerAppDBContext db)
        {
            this.db_Context = db;
        }

        public bool CreateDesktop(Desktop desktop)
        {
            try
            {
                db_Context.Desktops.Add(desktop);
                SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteDesktop(int id)
        {
            try
            {
                var user = db_Context.Desktops.Find(id);
                db_Context.Desktops.Remove(user);
                SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IEnumerable<Desktop> GetAllDesktops()
        {
            return db_Context.Desktops.ToList();
        }

        public Desktop GetDesktopById(int id)
        {
            return db_Context.Desktops.FirstOrDefault(p => p.DesktopId == id);
        }

        public void SaveChanges()
        {
            db_Context.SaveChanges();
        }

        public bool UpdateDesktop(Desktop desktop)
        {
            try
            {
                db_Context.Entry(desktop).State = EntityState.Modified;
                SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw new ArgumentNullException(nameof(desktop));
            }
        }         
    }
}
