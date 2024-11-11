using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shoppingWebBackend.Data;
using shoppingWebBackend.Models;
using System.Collections.Generic;

namespace shoppingWebBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Dictionary<string, List<ProductModel>>>> GetProductsGroupByCategory()
        {
            var res = new Dictionary<string, List<ProductModel>>();
            foreach(var cat in _context.Categories)
            {
                res[cat.Name] = await _context.Products.Include(p => p.Category).ToListAsync();
            }
            return res;
        }
    }
}
