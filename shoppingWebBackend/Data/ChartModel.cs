namespace shoppingWebBackend.Data
{
    public class ChartModel
    {
        public int chart_id { get; set; }

        public string buyer_name { get; set; }
        public string buyer_address { get; set; }
        public string buyer_mail { get; set; }
        public List<ChartItemsModel> ChartProducts { get; set; }

    }
}
