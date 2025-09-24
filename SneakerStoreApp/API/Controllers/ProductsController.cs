using API.Models;
using Microsoft.AspNetCore.Mvc;
using SneakerStoreApp.API.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // https://localhost:5001/api/products
    public class ProductsController(StoreContext context) : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            return context.Products.ToList();
        }

        [HttpGet("{id}")] // https://localhost:5001/api/products/3
        public ActionResult<Product> GetProduct(int id)
        {
            var product = context.Products.Find(id);

            if (product == null) return NotFound();

            return product;
        }
    }
}