using ECommerceSite.API.Interface;
using ECommerceSite.API.Models;
using ECommerceSite.API.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceSite.API.Repositories
{
    public class ProductRepository : IProductsRepository
    {
        private readonly ECommerceDbContext _context;

        public ProductRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, ProductInputModel productInputModel)
        {
            var product = await GetProductById(id);

            if(product != null)
            {
                product.Descripition = productInputModel.Description;
                product.Price = productInputModel.Price;

                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task DeleteItem(int id)
        {
            var product = await GetProductById(id);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
          
        }
    }
}
