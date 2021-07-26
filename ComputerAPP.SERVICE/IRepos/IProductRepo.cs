using ComputerAPP.CORE.Models;
using System.Collections.Generic;

namespace ComputerAPP.SERVICE
{
    interface IProductRepo
    {
        void SaveChanges();
        IEnumerable<IProduct> GetAllProducts();
        IProduct GetProductById(int id);
        void CreateProduct(IProduct product);
        void UpdateProduct(int id, IProduct product);
        void DeleteProduct(int id);
    }
}
