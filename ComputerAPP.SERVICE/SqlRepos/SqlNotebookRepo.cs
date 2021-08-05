using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAPP.SERVICE.SqlRepos
{
    public class SqlNotebookRepo : INotebookRepo
    {
        private readonly ComputerAppDBContext db_Context;

        public SqlNotebookRepo(ComputerAppDBContext db)
        {
            this.db_Context = db;
        }

        public async Task<bool> AddNotebook(Notebook notebook)
        {
            try
            {
                await db_Context.NoteBooks.AddAsync(notebook);
                await db_Context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> DeleteNotebook(int id)
        {
            try
            {
                var notebook = await db_Context.NoteBooks.FindAsync(id);
                db_Context.NoteBooks.Remove(notebook);
                await db_Context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<IEnumerable<Notebook>> GetAllNotebooks()
        {
            return await db_Context.NoteBooks.ToListAsync();
        }

        public IEnumerable<Notebook> SearchNotebooks(string search)
        {
            try
            {
                return db_Context.NoteBooks.Where(p => p.Brand.Contains(search));
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public async Task<Notebook> GetNotebookById(int id)
        {
            return await db_Context.NoteBooks.FirstOrDefaultAsync(p => p.NoteBookId == id);
        }

        public async Task<bool> UpdateNotebook(Notebook notebook)
        {
            try
            {
                db_Context.Entry(notebook).State = EntityState.Modified;
                await db_Context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw new ArgumentNullException(nameof(notebook));
            }
        }
    }
}

