using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shoppingWebBackend.Data;
using shoppingWebBackend.Utils;

namespace shoppingWebBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingController : Controller
    {
        private readonly AppDbContext _context;

        public ShoppingController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostDictionary([FromBody] ShopRequest shopRequest)
        {

            if (shopRequest == null)
            {
                return BadRequest("No data received.");
            }

            string name = shopRequest.Name;
            string address = shopRequest.Address;
            string mail = shopRequest.Mail;
            Dictionary<int, int> data = shopRequest.Data;

            var newChart = new ChartModel
            {
                Address = address,
                FullName = name,
                Mail = mail,
            };

            _context.Charts.Add(newChart);

            await _context.SaveChangesAsync();

            var id = newChart.ChartId;

            foreach (var entry in data)
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == entry.Key);

                var boughtProduct = new ChartItemsModel
                {
                    ChartId = id,
                    ProductId = entry.Key,
                    Quantity = entry.Value,
                    Product = product,
                    Chart = newChart
                };

                _context.ChartProducts.Add(boughtProduct);
            }

            await _context.SaveChangesAsync();

            return Ok(shopRequest);
        }
    }
}
