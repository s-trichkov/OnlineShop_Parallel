using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace OnlineShop_Parallel
{
    class Program
    {
        public static bool ShopTest()
        {
            ShopController shopController;

            Dictionary<Product, int> Stock = new Dictionary<Product, int>();

            List<Buyer> buyers = new List<Buyer>();
            List<Supplier> suppliers = new List<Supplier>();

            List<Thread> threads = new List<Thread>();

            Random rand = new Random();

            for (int i = 1; i <= 20; i++)
            {
                Stock.Add(new Product("Book " + i, "bo", 9.95), rand.Next(1, 15));
            }

            for (int i = 1; i <= 100; i++)
            {
                buyers.Add(new Buyer("Brooks " + i, "brookie", "54", "b@m.com", "boboboo"));
            }

            for (int i = 1; i < 5; i++)
            {
                suppliers.Add(new Supplier("VizMedia " + i, "vizM", "vizzyDrink", "VizMedia LLC'"));
            }

            shopController = new ShopController(Stock);

            foreach (var buyer in buyers)
            {
                int numberOfProducts = rand.Next(0, Stock.Count);

                Product product = null;

                Dictionary<Product, int> productDictionary = new Dictionary<Product, int>();

                for (int i = 0; i < numberOfProducts - 1; i++)
                {
                    product = Stock.ToList()[rand.Next(0, Stock.Count - 1)].Key;

                    if (productDictionary.ContainsKey(product))
                    {
                        productDictionary[product] += 1;
                    }
                    else
                    {
                        productDictionary.Add(product, rand.Next(1, 10));
                    }
                }

                Thread t = new Thread(() => shopController.ProductPurchase(buyer, productDictionary));
                threads.Add(t);
                t.Start();
            }

            foreach (var supplier in suppliers)
            {
                int numberOfProducts = rand.Next(0, Stock.Count);

                Product product = null;

                Dictionary<Product, int> productDictionary = new Dictionary<Product, int>();

                for (int i = 0; i < numberOfProducts - 1; i++)
                {
                    product = Stock.ToList()[rand.Next(0, Stock.Count - 1)].Key;

                    if (productDictionary.ContainsKey(product))
                    {
                        productDictionary[product] += 1;
                    }
                    else
                    {
                        productDictionary.Add(product, rand.Next(1, 10));
                    }
                }

                Thread t = new Thread(() => shopController.ProductSupply(productDictionary));
                threads.Add(t);
                t.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            return true;
        }

        static void Main(string[] args)
        {
            bool testResult = ShopTest();

            if (testResult)
            {
                Console.WriteLine("Completed test successfully!");
            }
            else
            {
                Console.WriteLine("Test Failed! XXX");
            }
        }
    }
}
