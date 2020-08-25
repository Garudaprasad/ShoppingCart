using System;
using System.Collections.Generic;

namespace ShoppingCart
{
    public class Store
    {
        private List<Product> _products;

        public List<Product> AllProducts
        {
            get { return _products; }
        }

        private Store()
        {
            _products = new List<Product>();
        }
    }
}
