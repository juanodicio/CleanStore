using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }

        public List<ProductImage> Images { get; set; }
    }
}