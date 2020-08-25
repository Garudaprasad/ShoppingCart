using System.Text;

namespace ProblemStatement1
{
    public class Billing
    {
        private static Billing _instance;
        private StringBuilder _finalBill;
        private decimal _total = 0;

        public static Billing Instance
        {
            get
            {
                return _instance;
            }
        }

        public string FinalBill
        {
            get { return _finalBill.ToString(); }
        }

        public decimal BillTotal
        {
            get { return _total; }
        }


        private Billing()
        {

        }

        public void Bill(Cart cart)
        {
            _finalBill = new StringBuilder();
            _total = 0;
            decimal totals = 0;

            PromotionFactory.Instance.PromotionOneInstance.Bill(cart.AllPurchases, ref _finalBill, ref totals);
            _total += totals;

            PromotionFactory.Instance.PromotionTwoInstance.Bill(cart.AllPurchases, ref _finalBill, ref totals);
            _total += totals;

            PromotionFactory.Instance.Bill(cart.AllPurchases, ref _finalBill, ref totals);
            _total += totals;

            _finalBill.Append("\n================\n");
            _finalBill.Append("Total\t" + _total);
        }
    }
}
