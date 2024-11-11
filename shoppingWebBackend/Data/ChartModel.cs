namespace shoppingWebBackend.Data
{
    public class ChartModel
    {
        public int ChartId { get; set; }

        public string FullName { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
        public List<ChartItemsModel> ChartProducts { get; set; }

    }
}
