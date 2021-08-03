using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerAPP.SERVICE
{
    interface IProductRepo<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllProducts();
        Task<TEntity> GetProductById(int id);
        Task<bool> CreateProduct(TEntity entity);
        Task<bool> UpdateProduct(TEntity entity);
        Task<bool> DeleteProduct(int id);
    }
}
