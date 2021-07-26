using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerAPP.SERVICE.ValidationServices
{
    public class SqlDesktopRepo : IProductRepo
    {
        private readonly ComputerAppDBContext db_Context;

        public SqlDesktopRepo(ComputerAppDBContext db)
        {
            this.db_Context = db;
        }

        public void CreateProduct(IProduct desktop)
        {
            db_Context.Desktops.Add((Desktop)desktop);
        }

        public void DeleteProduct(int id)
        {
            var desktop = db_Context.Desktops.Find(id);
            if (desktop == null)
            {
                throw new ArgumentNullException(nameof(desktop));
            }
            db_Context.Desktops.Remove(desktop);
        }

        public IProduct GetProductById(int id)
        {
            return db_Context.Desktops.FirstOrDefault(p => p.DesktopId == id);
        }

        public IEnumerable<IProduct> GetAllProducts()
        {
            return db_Context.Desktops.ToList();
        }

        public void SaveChanges()
        {
            db_Context.SaveChanges();
        }

        public void UpdateProduct(int id, IProduct desktop)
        {
            db_Context.Entry(desktop).State = EntityState.Modified;
            SaveChanges();
        }
    }
}
