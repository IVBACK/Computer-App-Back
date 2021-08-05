using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using ComputerAPP.SERVICE.IRepos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerAPP.SERVICE.SqlRepos
{
    public class SqlDesktopRepo : IDesktopRepo
    {
        private readonly ComputerAppDBContext db_Context;

        public SqlDesktopRepo(ComputerAppDBContext db)
        {
            this.db_Context = db;
        }

        public async Task<bool> AddDesktop(Desktop desktop)
        {
            try
            {
                await db_Context.Desktops.AddAsync(desktop);
                await db_Context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }          
        }

        public async Task<bool> DeleteDesktop(int id)
        {
            try
            {
                var desktop = await db_Context.Desktops.FindAsync(id);
                db_Context.Desktops.Remove(desktop);
                await db_Context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<IEnumerable<Desktop>> GetAllDesktops()
        {
            return await db_Context.Desktops.ToListAsync();
        }

        public async Task<Desktop> GetDesktopById(int id)
        {
            return await db_Context.Desktops.FirstOrDefaultAsync(p => p.DesktopId == id);
        }

        public async Task<bool> UpdateDesktop(Desktop desktop)
        {
            try
            {
                db_Context.Entry(desktop).State = EntityState.Modified;
                await db_Context.SaveChangesAsync();
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

