namespace shoppingWebBackend.Data
{
    public class ChartItemsModel
    {
        public int list_id { get; set; }

        public int chart_id { get; set; }
        public ChartModel Chart { get; set; }

        public int product_id { get; set; }
        public ProductModel Product { get; set; }

        public int quantity { get; set; }
    }

}
