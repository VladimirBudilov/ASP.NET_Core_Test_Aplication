using Core.Infrastructure;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts(ILogger<ProductsController> logger)
        {
            logger.LogInformation("Getting products");
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(ILogger<ProductsController> logger)
        {
            logger.LogInformation("Getting product");
            Product? product = await _context.Products.FirstOrDefaultAsync();
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async void AddProduct([FromBody] ProductDto product)
        {
            _context.Products.Add(new Product { Name = product.Name, CategoryId = product.CategoryId });
            await _context.SaveChangesAsync();
        }

        [HttpPut]
        public async void UpdateProduct([FromBody] Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async void DeleteProduct(Guid id)
        {
            _context.Products.Remove(new Product { Id = id });
            await _context.SaveChangesAsync();
        }

        [HttpGet("redirect")]
        public IActionResult Redirect()
        {
            return Redirect("https://www.google.com");
        }
    }
}
