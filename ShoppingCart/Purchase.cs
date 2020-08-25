namespace ProblemStatement1
{
    public class Purchase
    {

        private int _quantity;
        private Product _prod;

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public string ProductName
        {
            get { return _prod?.ProductName; }
        }

        public Product Prod
        {
            get { return _prod; }
        }


        public Purchase(Product product, int quantity)
        {
            this._prod = product;
            this._quantity = quantity;
        }
    }
}
