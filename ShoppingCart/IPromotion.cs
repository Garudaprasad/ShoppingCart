using System.Collections.Generic;
using System.Text;

namespace ProblemStatement1
{
    public interface IPromotion
    {
        void Bill(List<Purchase> purchases, ref StringBuilder billAsString, ref decimal total);
    }
}
