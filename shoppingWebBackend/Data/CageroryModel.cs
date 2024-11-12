using Microsoft.EntityFrameworkCore;
using shoppingWebBackend.Data;

namespace shoppingWebBackend.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string category_description { get; set; }
        public List<ProductModel> Products { get; set; }
    }

}
