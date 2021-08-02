using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using ComputerAPP.SERVICE.IRepos;
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


        public bool CreateNotebook(NoteBook notebook)
        {
            try
            {
                db_Context.NoteBooks.Add(notebook);
                SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteNotebook(int id)
        {
            try
            {
                var user = db_Context.NoteBooks.Find(id);
                db_Context.NoteBooks.Remove(user);
                SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IEnumerable<NoteBook> GetAllNotebooks()
        {
            return db_Context.NoteBooks.ToList();
        }

        public NoteBook GetNotebookById(int id)
        {
            return db_Context.NoteBooks.FirstOrDefault(p => p.NoteBookId == id);
        }

        public void SaveChanges()
        {
            db_Context.SaveChanges();
        }

        public bool UpdateNotebook(NoteBook notebook)
        {
            try
            {
                db_Context.Entry(notebook).State = EntityState.Modified;
                SaveChanges();
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
