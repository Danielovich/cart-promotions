using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Promotions
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class ProductBundle
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }



    public class Cart
    {
        public Cart()
        {
            CartProducts = new List<Product>();
        }

        public List<Product> CartProducts { get; set; }

        public double Sum(IEnumerable<Product> products)
        {
            return products.Sum(s => s.Price);
        }

        public void Add(Product product)
        {
            CartProducts.Add(product);
        }

    }
}
