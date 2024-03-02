using Core.Infrastructure;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
          return _context.Products;
        }

        [HttpGet("{id}")]
        public Product GetProduct(ILogger<ProductsController> logger)
        {
            logger.LogInformation("Getting product");
            return _context.Products.FirstOrDefault();
        }

        [HttpPost]
        public void AddProduct([FromBody]ProductDto product)
        {
            _context.Products.Add(new Product { Name = product.Name, CategoryId = product.CategoryId });
            _context.SaveChanges();
        }
    }
}
