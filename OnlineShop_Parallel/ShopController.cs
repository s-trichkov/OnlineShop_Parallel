using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop_Parallel
{
    public class ShopController
    {
        public Dictionary<Product, int> Stock { get; set; }
        public ShopController(Dictionary<Product, int> stock)
        {
            Stock = stock;
        }

        object task = new object();

        public void ProductSupply(Dictionary<Product, int> productsToSupply)
        {
            foreach (var productToSupply in productsToSupply)
            {
                lock (task)
                {
                    if (Stock.ContainsKey(productToSupply.Key))
                    {
                        Stock[productToSupply.Key] += productToSupply.Value;
                    }
                    else
                    {
                        Stock.Add(productToSupply.Key, productToSupply.Value);
                    }
                }
            }
            Console.WriteLine("Successfully supplied a product!");

        }

        public EnumStatus ProductPurchase(Buyer buyer, Dictionary<Product, int> productsToBuy)
        {
            lock (task)
            {
                bool flag = false;
                foreach (var productToBuy in productsToBuy)
                {
                    if (Stock.ContainsKey(productToBuy.Key) && Stock[productToBuy.Key] >= productToBuy.Value)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    foreach (var productToBuy in productsToBuy)
                    {
                        Stock[productToBuy.Key] -= productToBuy.Value;
                        Console.WriteLine(buyer.Name + " successfully purchased: " + productToBuy.Key.Name);
                    }

                    return EnumStatus.Success;

                }
                else
                {
                    Console.WriteLine("Purchasing failed: Out of stock!");
                    return EnumStatus.Failed;
                }

            }
        }
        public Product GetProductByName(string name)
        {
            Product product = Stock.Where(p => p.Key.Name.Equals(name)).FirstOrDefault().Key;

            return product;
        }
    }
}
