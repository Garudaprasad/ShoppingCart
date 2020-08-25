using System.Collections.Generic;

namespace ProblemStatement1
{
    public class Cart
    {
        private List<Purchase> _purchases;        

        public List<Purchase> AllPurchases
        {
            get { return _purchases; }
        }
        
        public Cart()
        {
            _purchases = new List<Purchase>();
        }
    }
}
