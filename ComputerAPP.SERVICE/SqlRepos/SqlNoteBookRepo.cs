using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ComputerAPP.SERVICE
{
    public class SqlNoteBookRepo : IProductRepo
    {
        private readonly ComputerAppDBContext db_Context;

        public SqlNoteBookRepo(ComputerAppDBContext db)
        {
            this.db_Context = db;
        }

        public void CreateProduct(IProduct noteBook)
        {
            db_Context.NoteBooks.Add((NoteBook)noteBook);
        }

        public void DeleteProduct(int id)
        {
            var noteBook = db_Context.NoteBooks.Find(id);
            if (noteBook == null)
            {
                throw new ArgumentNullException(nameof(noteBook));
            }
            db_Context.NoteBooks.Remove(noteBook);
        }

        public IEnumerable<IProduct> GetAllProducts()
        {
            return db_Context.NoteBooks.ToList();
        }

        public IProduct GetProductById(int id)
        {
            return db_Context.NoteBooks.FirstOrDefault(p => p.NoteBookId == id);
        }

        public void SaveChanges()
        {
            db_Context.SaveChanges();
        }

        public void UpdateProduct(int id, IProduct noteBook)
        {
            db_Context.Entry(noteBook).State = EntityState.Modified;
            SaveChanges();
        }
    }
}