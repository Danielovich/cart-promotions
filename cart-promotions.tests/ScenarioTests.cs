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

        
        [Fact]
        public void ScenarioB()
        {
            //ARRANGE
            var A = new Product() { Name = "A", Price = 50 };
            var B = new Product() { Name = "B", Price = 30 };
            var C = new Product() { Name = "C", Price = 20 };

            var productBundles = new ProductBundles();

            //scenario b data set
            var cart = new Cart();
            cart.Add(A);
            cart.Add(A);
            cart.Add(A);
            cart.Add(A);
            cart.Add(A);
            cart.Add(B);
            cart.Add(B);
            cart.Add(B);
            cart.Add(B);
            cart.Add(B);
            cart.Add(C);
            
            //Yes, we go definitly use Product instead of string, but let's KISS
            var flattenedCart = new List<string>(cart.CartProducts.Select(p => p.Name).ToList());

            //Returning result from the recursing method - could perhaps have yieled
            var cartBundles = new List<string>();

            var promotionCalculator = new PromotionCalculator();
            
            //ACT
            //Find the applicabale bundles in the cart 
            promotionCalculator.ApplicablePromotions(flattenedCart, productBundles.ActiveBundles, cartBundles);

            //Explicit Sum by remaing cart items
            var sum = cart.Sum(flattenedCart);

            //Plus prices for bundles
            sum += cart.Sum(cartBundles, productBundles.ActiveBundles);

            //ASSERT
            Assert.True(sum == 370);
        }

        [Fact]
        public void ScenanarioC()
        {
            //ARRANGE
            var A = new Product() { Name = "A", Price = 50 };
            var B = new Product() { Name = "B", Price = 30 };
            var C = new Product() { Name = "C", Price = 20 };
            var D = new Product() { Name = "D", Price = 15 };

            var productBundles = new ProductBundles();

            //scenario b data set
            var cart = new Cart();
            cart.Add(A);
            cart.Add(A);
            cart.Add(A);
            cart.Add(B);
            cart.Add(B);
            cart.Add(B);
            cart.Add(B);
            cart.Add(B);
            cart.Add(C);
            cart.Add(D);

            //Yes, we go definitly use Product instead of string, but let's KISS
            var flattenedCart = new List<string>(cart.CartProducts.Select(p => p.Name).ToList());

            //Returning result from the recursing method - could perhaps have yieled
            var cartBundles = new List<string>();

            var promotionCalculator = new PromotionCalculator();

            //Find the applicabale bundles in the cart 
            promotionCalculator.ApplicablePromotions(flattenedCart, productBundles.ActiveBundles, cartBundles);

            //Explicit Sum by remaing cart items
            var sum = cart.Sum(flattenedCart);

            //Plus prices for bundles
            sum += cart.Sum(cartBundles, productBundles.ActiveBundles);

            //ASSERT
            Assert.True(sum == 280);
        }

    }
}
