using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shoppingWebBackend.Data;
using shoppingWebBackend.Utils;

namespace shoppingWebBackend.Controllers
{
    [ApiController]
    public class ShoppingController : Controller
    {
        private readonly AppDbContext _context;

        public ShoppingController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("/add")]
        public async Task<IActionResult> PostDictionary([FromBody] ShopRequest shopRequest)
        {

            if (shopRequest == null)
            {
                return BadRequest("No data received.");
            }

            string name = shopRequest.Name;
            string address = shopRequest.Address;
            string mail = shopRequest.Mail;
            //Dictionary<string, int> data = shopRequest.Data;
            Dictionary<int, int> data = shopRequest.Data;

            var newChart = new ChartModel
            {
                buyer_address = address,
                buyer_name = name,
                buyer_mail = mail,
            };

            _context.Charts.Add(newChart);

            await _context.SaveChangesAsync();

            var id = newChart.chart_id;

            foreach (var entry in data)
            {
                //int productShoppedId = int.Parse(entry.Key);
                int productShoppedId = entry.Key;
                var product = await _context.Products.FirstOrDefaultAsync(p => p.product_id == productShoppedId);

                var boughtProduct = new ChartItemsModel
                {
                    chart_id = id,
                    product_id = productShoppedId,
                    quantity = entry.Value,
                    Product = product,
                    Chart = newChart
                };

                _context.ChartProducts.Add(boughtProduct);
            }

            var response = await _context.SaveChangesAsync();

            return Ok(response);
        }
    }
}
