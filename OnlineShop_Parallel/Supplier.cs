using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop_Parallel
{
    public class Supplier : User
    {
        public string SupplierName { get; set; }
        public Supplier(string name, string username, string password, string supplierName) : base(name, username, password)
        {
            SupplierName = supplierName;
        }
    }
}
