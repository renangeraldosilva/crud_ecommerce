using ECommerceSite.API.Interface;
using ECommerceSite.API.Models;
using ECommerceSite.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceSite.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _iProductsRepository;

        public ProductsController(IProductsRepository ecommerceDbContext)
        {
            _iProductsRepository = ecommerceDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _iProductsRepository.GetAllProducts();    
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _iProductsRepository.GetProductById(id);

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductInputModel productInputModel)
        {
            if (productInputModel == null)
            {
                return BadRequest();
            }

            var product = new Product(productInputModel.Description, productInputModel.Price);

            await _iProductsRepository.AddAsync(product);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProductInputModel productInputModel)
        {
            await _iProductsRepository.UpdateAsync(id, productInputModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _iProductsRepository.DeleteItem(id);

            return Ok();
        }
    }
}
