namespace shoppingWebBackend.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public CageroryModel Category { get; set; }
    }
}
