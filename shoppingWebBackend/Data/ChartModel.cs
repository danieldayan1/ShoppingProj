namespace shoppingWebBackend.Data
{
    public class ChartModel
    {
        public int ChartId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public List<ChartItemsModel> ChartProducts { get; set; }

    }
}
