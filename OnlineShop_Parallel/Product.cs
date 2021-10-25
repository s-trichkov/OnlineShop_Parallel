using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop_Parallel
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Product(string name, string description, double price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
