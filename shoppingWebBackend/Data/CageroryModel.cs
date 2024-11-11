﻿using shoppingWebBackend.Data;

namespace shoppingWebBackend.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductModel> Products { get; set; }
    }

}