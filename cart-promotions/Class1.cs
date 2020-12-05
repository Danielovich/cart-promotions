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

    public class PromotionCalculator
    {
        public void ApplicablePromotions(List<string> cart, Dictionary<string, double> bundles, List<string> result)
        {
            var match = false;

            if (cart.Count() > 0)
            {
                foreach (var bundle in bundles)
                {
                    var bundleKey = bundle.Key.ToArray();
                    var keyMatchCounter = 0;

                    var cartCopy = new List<string>(cart);
                    foreach (var key in bundleKey)
                    {
                        if (cartCopy.Any(a => a == key.ToString()))
                        {
                            keyMatchCounter++;
                            cartCopy.Remove(key.ToString());
                        }
                    }

                    //match bundle
                    if (keyMatchCounter == bundleKey.Length)
                    {
                        match = true;
                        result.Add(bundle.Key);

                        foreach (var keyChar in bundleKey)
                        {
                            if (cart.Count > 0)
                                cart.Remove(keyChar.ToString());
                        }
                    }
                }

                if (match)
                    ApplicablePromotions(cart, bundles, result);
            }
        }
    }

    public class ProductBundles
    {
        public ProductBundles()
        {
            ActiveBundles = new Dictionary<string, double>();

            Setup();
        }

        public Dictionary<string, double> ActiveBundles { get; }

        private void Setup()
        {
            ActiveBundles.Add("AAA", 130);
            ActiveBundles.Add("BB", 45);
            ActiveBundles.Add("CD", 30);
        }
    }
}
