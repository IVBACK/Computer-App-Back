using ComputerAPP.DATA.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerAPP.SERVICE.SqlRepos
{
    public class SqlProductRepo<TEntity> : IProductRepo<TEntity> where TEntity : class
    {
        private readonly ComputerAppDBContext db_Context;

        public SqlProductRepo(ComputerAppDBContext db)
        {
            this.db_Context = db;
        }

        public bool CreateProduct(TEntity entity)
        {
            try
            {
                db_Context.Set<TEntity>().Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;               
            }           
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                TEntity entity = db_Context.Set<TEntity>().Find(id);
                db_Context.Set<TEntity>().Remove(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }          
        }

        public IEnumerable<TEntity> GetAllProducts()
        {
            try
            {
                return db_Context.Set<TEntity>().ToList();
            }
            catch (Exception)
            {
                return null;
                throw;
            }          
        }

        public TEntity GetProductById(int id)
        {
            try
            {
                return db_Context.Set<TEntity>().Find(id);
            }
            catch (Exception)
            {
                return null;
                throw;
            }           
        }

        public bool UpdateProduct(TEntity entity)
        {
            try
            {
                db_Context.Entry(entity).State = EntityState.Modified;
                SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw new ArgumentNullException(nameof(entity));
            }
        }

        public void SaveChanges()
        {
            db_Context.SaveChanges();
        }
    }
}
