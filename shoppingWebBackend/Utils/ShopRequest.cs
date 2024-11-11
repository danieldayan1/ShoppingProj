namespace shoppingWebBackend.Utils
{
    public class ShopRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public Dictionary<int, int> Data { get; set; }
    }
}
