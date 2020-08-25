using System.Collections.Generic;
using System.Text;

namespace ProblemStatement1
{
    public class PromotionOne : IPromotion
    {
        private List<PromotionOneData> _data;

        public List<PromotionOneData> Data
        {
            get { return _data; }
        }

        public PromotionOne()
        {
            _data = new List<PromotionOneData>();            
        }

        public void AddNewPromotion(string productname, int units, decimal offerPrice)
        {
            _data.Add(new PromotionOneData(productname, units, offerPrice));
        }

        public void RemovePromotion(PromotionOneData promotionData)
        {
            if(_data.IndexOf(promotionData) > -1)
            {
                _data.Remove(promotionData);
            }
        }

        public void Bill(List<Purchase> purchases, ref StringBuilder billAsString, ref decimal total)
        {
            total = 0;
            if (_data != null && _data.Count > 0 && purchases.Count > 0)
            {
                foreach (PromotionOneData promotions in _data)
                {
                    Purchase matched = purchases.Find(u => u.ProductName == promotions.ProductName);

                    if (matched == null) continue;

                    if (matched.Quantity >= promotions.Units)
                    {
                        billAsString.Append(matched.Quantity + " * " + promotions.ProductName + "\t=\t");

                        for(int index = 0; index < (matched.Quantity / promotions.Units); index++)
                        {
                            if(index == 0)
                            {
                                billAsString.Append(" " + promotions.OfferPrice);
                            }
                            else
                            {
                                billAsString.Append(" + " + promotions.OfferPrice);
                            }

                            total += promotions.OfferPrice;
                        }

                        if (matched.Quantity % promotions.Units > 0)
                        {
                            billAsString.Append(" + " + (matched.Quantity % promotions.Units) + " * " + matched.Prod.ProductPrice + "\n");
                            total += (matched.Quantity % promotions.Units) * matched.Prod.ProductPrice;
                        }
                        else
                        {
                            billAsString.Append("\n");
                        }
                    }
                    else
                    {
                        billAsString.Append(matched.Quantity + " * " + promotions.ProductName + "\t=\t" + (matched.Quantity * matched.Prod.ProductPrice) + "\n");
                        total += (matched.Quantity * matched.Prod.ProductPrice);
                    }
                }
            }
        }
    }
}
