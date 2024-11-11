using shoppingWebBackend.Models;

namespace shoppingWebBackend.Data
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        public List<ChartItemsModel> ChartProducts { get; set; }
    }
}
