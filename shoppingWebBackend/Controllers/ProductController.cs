using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shoppingWebBackend.Data;
using shoppingWebBackend.Models;
using System.Collections.Generic;

namespace shoppingWebBackend.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
      
        }

        [HttpGet()]
        [Route("/products")]
        public async Task<ActionResult<Dictionary<string, List<ProductModel>>>> GetProductsGroupByCategory()
        {
            var res = new Dictionary<string, List<ProductModel>>();
            var groupedProducts = await _context.Products
                .GroupBy(p => p.Category.category_description) // Group products by CategoryId
                .Select(g => new
                {
                    CategoryDescription= g.Key,
                    Products = g.ToList()
                })
                .ToListAsync();
            
            foreach (var pair in groupedProducts)
            {
                res[pair.CategoryDescription] = pair.Products;
            }
            return res;
        }
    }
}
