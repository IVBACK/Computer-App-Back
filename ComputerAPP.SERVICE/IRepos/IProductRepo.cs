using System.Collections.Generic;

namespace ComputerAPP.SERVICE
{
    interface IProductRepo<TEntity> where TEntity : class
    {
        void SaveChanges();
        IEnumerable<TEntity> GetAllProducts();
        TEntity GetProductById(int id);
        bool CreateProduct(TEntity entity);
        bool UpdateProduct(TEntity entity);
        bool DeleteProduct(int id);
    }
}
