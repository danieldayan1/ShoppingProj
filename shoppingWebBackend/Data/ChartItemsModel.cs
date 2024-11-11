namespace shoppingWebBackend.Data
{
    public class ChartItemsModel
    {
        public int Id { get; set; }

        public int ChartId { get; set; }
        public ChartModel Chart { get; set; }

        public int ProductId { get; set; }
        public ProductModel Product { get; set; }

        public int Quantity { get; set; }
    }

}
