using System;
using System.Collections.Generic;
using System.Text;


namespace ProblemStatement1
{
    public class PromotionFactory: IPromotion
    {
        private static PromotionFactory _instance = new PromotionFactory();

        public static PromotionFactory Instance
        {
            get
            {
                return _instance;
            }
        }

        private PromotionFactory()
        {

        }

        public void Bill(List<Purchase> purchases, ref StringBuilder billAsString, ref decimal total)
        {
            total = 0;
            foreach(Purchase pur in purchases)
            {
                billAsString.Append(pur.Quantity + " * " + pur.ProductName + "\t=\t" + (pur.Quantity * pur.Prod.ProductPrice) + "\n");
                total += (pur.Quantity * pur.Prod.ProductPrice);
            }
        }
    }
}
