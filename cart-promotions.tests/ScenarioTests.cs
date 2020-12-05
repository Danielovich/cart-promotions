using Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Promotions.Tests
{
    public class ScenarioTests
    {
        [Fact]
        public void SceneriaA()
        {
            var A = new Product() { Name = "A", Price = 50 };
            var B = new Product() { Name = "B", Price = 30 };
            var C = new Product() { Name = "C", Price = 20 };

            var cart = new Cart();

            cart.Add(A);
            cart.Add(B);
            cart.Add(C);

            var sum = cart.Sum(cart.CartProducts);

            Assert.True(sum == 100);
        }

        


    }
}
