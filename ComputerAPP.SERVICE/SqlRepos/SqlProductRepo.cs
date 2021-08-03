using ComputerAPP.DATA.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerAPP.SERVICE.SqlRepos
{

    public class SqlProductRepo<TEntity> : IProductRepo<TEntity> where TEntity : class
    {

        private readonly ComputerAppDBContext db_Context;

        public SqlProductRepo(ComputerAppDBContext db)
        {
            this.db_Context = db;
        }

        public async Task<bool> CreateProduct(TEntity entity)
        {
            try
            {
                await db_Context.Set<TEntity>().AddAsync(entity);
                await db_Context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;               
            }           
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                TEntity entity = await db_Context.Set<TEntity>().FindAsync(id);
                db_Context.Set<TEntity>().Remove(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }          
        }

        public async Task<IEnumerable<TEntity>> GetAllProducts()
        {
            try
            {
                return await db_Context.Set<TEntity>().ToListAsync();
            }
            catch (Exception)
            {
                return null;
                throw;
            }          
        }

        public async Task<TEntity> GetProductById(int id)
        {
            try
            {
                return await db_Context.Set<TEntity>().FindAsync(id);
            }
            catch (Exception)
            {
                return null;
                throw;
            }           
        }

        public async Task<bool> UpdateProduct(TEntity entity)
        {
            try
            {
                db_Context.Entry(entity).State = EntityState.Modified;
                await db_Context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw new ArgumentNullException(nameof(entity));
            }
        }
    }
}
