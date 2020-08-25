using System;
using System.Collections.Generic;
using System.Text;


namespace ProblemStatement1
{
    public class PromotionFactory: IPromotion
    {
        private static PromotionFactory _instance = new PromotionFactory();
        private List<string> _productNamesPromoted;
        private PromotionOne _promotionOne;
        private PromotionTwo _promotionTwo;

        public static PromotionFactory Instance
        {
            get
            {
                return _instance;
            }
        }

        public PromotionOne PromotionOneInstance
        {
            get { return _promotionOne; }
        }
        public PromotionTwo PromotionTwoInstance
        {
            get { return _promotionTwo; }
        }

        private PromotionFactory()
        {
            this._productNamesPromoted = new List<string>();

            this._promotionOne = new PromotionOne();
            this._promotionTwo = new PromotionTwo();            
        }

        public bool AddNewPromotionOne(string productname, int units, decimal offerPrice)
        {
            if (productname.Equals(string.Empty) || units <= 1 || offerPrice <= 0)
            {
                return false;
            }

            if (this._productNamesPromoted.FindIndex(x => x.Equals(productname,
                    StringComparison.OrdinalIgnoreCase)) == -1)
            {
                this._promotionOne.AddNewPromotion(productname, units, offerPrice);
                this._productNamesPromoted.Add(productname);

                return true;
            }

            return false;
        }

        public bool AddNewPromotionTwo(string productname1, string productname2, decimal offerPrice)
        {
            if (productname1.Equals(string.Empty) || productname2.Equals(string.Empty) || offerPrice <= 0)
            {
                return false;
            }


            if (
                (!productname1.ToLower().Equals(productname2.ToLower())) 
                && (this._productNamesPromoted.FindIndex(x => x.Equals(productname1,
                    StringComparison.OrdinalIgnoreCase)) == -1)
                && (this._productNamesPromoted.FindIndex(x => x.Equals(productname2,
                   StringComparison.OrdinalIgnoreCase)) == -1))
            {
                this._promotionTwo.AddNewPromotion(productname1, productname2, offerPrice);
                this._productNamesPromoted.Add(productname1);
                this._productNamesPromoted.Add(productname2);

                return true;
            }

            return false;
        }

        public void RemovePromotionOne(PromotionOneData prom1)
        {
            this._promotionOne.RemovePromotion(prom1);
            this._productNamesPromoted.RemoveAll(u => u.Contains(prom1.ProductName));
        }

        public void RemovePromotionTwo(PromotionTwoData prom2)
        {
            this._promotionTwo.RemovePromotion(prom2);
            this._productNamesPromoted.RemoveAll(u => u.Contains(prom2.ProductOneName));
            this._productNamesPromoted.RemoveAll(u => u.Contains(prom2.ProductTwoName));
        }

        public void Bill(List<Purchase> purchases, ref StringBuilder billAsString, ref decimal total)
        {
            total = 0;
            if (_productNamesPromoted != null && purchases.Count > 0)
            {
                List<Purchase> nonPromotion = purchases.FindAll(p => !_productNamesPromoted.Contains(p.ProductName));

                if(nonPromotion != null && nonPromotion.Count > 0)
                {
                    foreach(Purchase pur in nonPromotion)
                    {
                        billAsString.Append(pur.Quantity + " * " + pur.ProductName + "\t=\t" + (pur.Quantity * pur.Prod.ProductPrice) + "\n");
                        total += (pur.Quantity * pur.Prod.ProductPrice);
                    }
                }
            }
        }
    }
}
