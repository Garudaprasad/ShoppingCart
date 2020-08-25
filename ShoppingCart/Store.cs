using System;
using System.Collections.Generic;

namespace ShoppingCart
{
    public class Store
    {
        private static Store _instance = new Store();
        private List<Product> _products;

        public static Store Instance
        {
            get
            {
                return _instance;
            }
        }

        public List<Product> AllProducts
        {
            get { return _products; }
        }

        private Store()
        {
            _products = new List<Product>();
        }

        public bool AddProductToStore(string productName, decimal price)
        {
            if (this.Exists(productName))
            {
                return false;
            }

            _products.Add(new Product(productName, price));
            return true;
        }

        private bool Exists(string productname)
        {
            return (this._products.FindIndex(x => x.ProductName.Equals(productname,
                   StringComparison.OrdinalIgnoreCase)) != -1);
        }
    }
}
