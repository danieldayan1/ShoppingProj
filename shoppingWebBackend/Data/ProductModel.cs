using shoppingWebBackend.Models;

namespace shoppingWebBackend.Data
{
    public class ProductModel
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public int category_id { get; set; }
        public CategoryModel Category { get; set; }
        public List<ChartItemsModel> ChartProducts { get; set; }
    }
}
