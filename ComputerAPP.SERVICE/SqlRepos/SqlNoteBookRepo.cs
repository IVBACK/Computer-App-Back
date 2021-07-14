using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ComputerAPP.SERVICE
{
    public class SqlNoteBookRepo : INoteBookRepo
    {
        private readonly ComputerAppDBContext db_Context;

        public SqlNoteBookRepo(ComputerAppDBContext db)
        {
            this.db_Context = db;
        }

        public void CreateNoteBook(NoteBook noteBook)
        {
            db_Context.NoteBooks.Add(noteBook);
        }

        public void DeleteNoteBook(int id)
        {
            var noteBook = db_Context.NoteBooks.Find(id);
            if (noteBook == null)
            {
                throw new ArgumentNullException(nameof(noteBook));
            }
            db_Context.NoteBooks.Remove(noteBook);
        }

        public IEnumerable<NoteBook> GetAllNoteBooks()
        {
            return db_Context.NoteBooks.ToList();
        }

        public NoteBook GetNoteBookById(int id)
        {
            return db_Context.NoteBooks.FirstOrDefault(p => p.NoteBookId == id);
        }

        public void SaveChanges()
        {
            db_Context.SaveChanges();
        }

        public void UpdateNoteBook(int id, NoteBook noteBook)
        {
            db_Context.Entry(noteBook).State = EntityState.Modified;
            SaveChanges();
        }
    }
}