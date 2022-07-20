using ECommerceSite.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceSite.API.Interface
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(int id, ProductInputModel productInputModel);
        Task DeleteItem(int id);
    }
}
