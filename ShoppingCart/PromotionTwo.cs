using System.Collections.Generic;
using System.Text;

namespace ProblemStatement1
{
    public class PromotionTwo : IPromotion
    {
        private List<PromotionTwoData> _data;

        public List<PromotionTwoData> Data
        {
            get { return _data; }
        }

        public PromotionTwo()
        {
            _data = new List<PromotionTwoData>();            
        }

        public void AddNewPromotion(string productname1, string productname2, decimal offerPrice)
        {
            _data.Add(new PromotionTwoData(productname1, productname2, offerPrice));
        }

        public void RemovePromotion(PromotionTwoData promotionData)
        {
            if (_data.IndexOf(promotionData) > -1)
            {
                _data.Remove(promotionData);
            }
        }

        public void Bill(List<Purchase> purchases, ref StringBuilder billAsString, ref decimal total)
        {
            total = 0;
            if (_data != null && _data.Count > 0 && purchases.Count > 0)
            {
                foreach (PromotionTwoData promotions in this._data)
                {
                    Purchase matched1 = purchases.Find(u => u.ProductName == promotions.ProductOneName);
                    Purchase matched2 = purchases.Find(u => u.ProductName == promotions.ProductTwoName);

                    if (matched1 != null && matched2 != null)
                    {
                        int difference = (matched1.Quantity > matched2.Quantity) ? 
                            matched1.Quantity - matched2.Quantity : 
                            matched2.Quantity - matched1.Quantity;

                        if (difference == 0)
                        {
                            billAsString.Append(matched1.Quantity + " * " + promotions.ProductOneName + "\t=\t-\n");
                            billAsString.Append(matched1.Quantity + " * " + promotions.ProductTwoName + "\t=\t" + (matched1.Quantity * promotions.OfferPrice) + "\n");
                            total = matched1.Quantity * promotions.OfferPrice;
                        }
                        else
                        {
                            if (matched1.Quantity < matched2.Quantity)
                            {
                                billAsString.Append(matched1.Quantity + " * " + promotions.ProductOneName + "\t=\t-" + "\n");
                                billAsString.Append(matched1.Quantity + " * " + promotions.ProductTwoName + "\t=\t" + (matched1.Quantity * promotions.OfferPrice) + "\n");
                                billAsString.Append(difference + " * " + promotions.ProductTwoName + "\t=\t" + (difference * matched2.Prod.ProductPrice) + "\n");
                                total = (matched1.Quantity * promotions.OfferPrice) + (difference * matched2.Prod.ProductPrice);
                            }
                            else
                            {
                                billAsString.Append(matched2.Quantity + " * " + promotions.ProductOneName + "\t=\t-" + "\n");
                                billAsString.Append(matched2.Quantity + " * " + promotions.ProductTwoName + "\t=\t" + (matched2.Quantity * promotions.OfferPrice) + "\n");
                                billAsString.Append(difference + " * " + promotions.ProductOneName + "\t=\t" + (difference * matched1.Prod.ProductPrice) + "\n");
                                total = (matched2.Quantity * promotions.OfferPrice) + (difference * matched1.Prod.ProductPrice);
                            }
                        }
                    }
                    else if (matched1 != null)
                    {
                        billAsString.Append(matched1.Quantity + " * " + promotions.ProductOneName + "\t=\t" + (matched1.Quantity * matched1.Prod.ProductPrice) + "\n");
                        total = (matched1.Quantity * matched1.Prod.ProductPrice);
                    }
                    else if (matched2 != null)
                    {
                        billAsString.Append(matched2.Quantity + " * " + promotions.ProductTwoName + "\t=\t" + (matched2.Quantity * matched2.Prod.ProductPrice) + "\n");
                        total = (matched2.Quantity * matched2.Prod.ProductPrice);
                    }
                }
            }
        }
    }
}
