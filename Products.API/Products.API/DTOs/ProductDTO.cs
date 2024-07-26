﻿using Products.API.Model;

namespace Products.API.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
