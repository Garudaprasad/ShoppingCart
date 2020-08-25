namespace ProblemStatement1
{
    public class PromotionTwoData
    {
        private string _productOneName;
        private string _productTwoName;
        private decimal _offerPrice;

        public string ProductOneName
        {
            get { return _productOneName; }
        }        

        public string ProductTwoName
        {
            get { return _productTwoName; }
        }        

        public decimal OfferPrice
        {
            get { return _offerPrice; }
        }

        public PromotionTwoData(string productname1, string productname2, decimal offerPrice)
        {
            this._productOneName = productname1;
            this._productTwoName = productname2;
            this._offerPrice = offerPrice;
        }
    }
}
