using ECommerceSite.API.Models;
using ECommerceSite.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ECommerceSite.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ECommerceDbContext _ecommerceDbContext;

        public ProductsController(ECommerceDbContext ecommerceDbContext)
        {
            _ecommerceDbContext = ecommerceDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _ecommerceDbContext.Products.ToList();    
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _ecommerceDbContext.Products.SingleOrDefault(p => p.Id == id);

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductInputModel productInputModel)
        {
            if (productInputModel == null)
            {
                return BadRequest();
            }

            var product = new Product(productInputModel.Description, productInputModel.Price);

            _ecommerceDbContext.Products.Add(product);
            _ecommerceDbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ProductInputModel productInputModel, int id)
        {

            if (productInputModel == null)
            {
                return BadRequest();
            }

            var product = _ecommerceDbContext.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            product.Descripition = productInputModel.Description;
            product.Price = productInputModel.Price;

            _ecommerceDbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var product = _ecommerceDbContext.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            _ecommerceDbContext.Products.Remove(product);
            _ecommerceDbContext.SaveChanges();

            return NoContent();
        }
    }
}
