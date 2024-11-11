namespace shoppingWebBackend.Models
{
    public class ChartModel
    {
        public int ChartId { get; set; }
        public int UserId { get; set; }
        public UserModel User{ get; set; }   
        public ChartModel Chart { get; set; }   
    }
}
