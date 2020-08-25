
namespace ProblemStatement1
{
    public class PromotionOneData
    {
        private string _productName;

        public string ProductName
        {
            get { return _productName; }
        }

        private int _units;

        public int Units
        {
            get { return _units; }
        }

        private decimal _offerPrice;

        public decimal OfferPrice
        {
            get { return _offerPrice; }
        }

        public PromotionOneData(string productname, int units, decimal offerPrice)
        {
            this._productName = productname;
            this._units = units;
            this._offerPrice = offerPrice;
        }
    }
}
