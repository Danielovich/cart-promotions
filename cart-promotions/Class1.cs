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

        public double Sum(IEnumerable<string> productNames)
        {
            double sum = 0;

            foreach (var product in productNames)
            {
                sum += Sum(product);
            }

            return sum;
        }
        public double Sum(IEnumerable<string> cartBundles, Dictionary<string, double> productBundles)
        {
            double sum = 0;
            foreach (var item in cartBundles)
            {
                sum += productBundles[item];
            }

            return sum;
        }
        public double Sum(string name)
        {
            return CartProducts.Where(w => w.Name == name).Select(p => p.Price).FirstOrDefault();
        }
    }

    public class PromotionCalculator
    {
        //This would look different based on how the implementation of Products would be in the real world.
        //But for the example the easiest is to look at the name of the Product and have a Dictionary where
        //The names are concatenated into a bundle; AAA, BB, CD. 
        //Then we can iterate over the bundles and count the number of Products (name string) in the cart
        //to find out if we have enough in the cart to apply a given bundle.
        //It was a fun excersise!
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
