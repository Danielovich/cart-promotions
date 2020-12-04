using Promotions;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{
    public class ProductTests
    {
        [Fact]
        public void SceneriaA()
        {
            var A = new Product() { Name = "A", Price = 50 };
            var B = new Product() { Name = "B", Price = 30 };
            var C = new Product() { Name = "C", Price = 20 };

            var products = new List<Product>();
            products.Add(A);
            products.Add(B);
            products.Add(C);

            var cart = new Cart();

            var sum = cart.Sum(products);

            Assert.True(sum == 100);
        }
    }
}
