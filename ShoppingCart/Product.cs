namespace ShoppingCart
{
    public class Product
    {
        private string _productName;
        private decimal _price;

        public string ProductName
        {
            get
            {
                return _productName;
            }
        }

        public decimal ProductPrice
        {
            get { return _price; }
        }

        public Product(string productName, decimal price)
        {
            this._productName = productName;
            this._price = price;
        }
    }
}
