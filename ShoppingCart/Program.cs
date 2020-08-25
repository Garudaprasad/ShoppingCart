using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingCart
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Store.Instance.AddProductToStore("A", 50);
            Store.Instance.AddProductToStore("B", 30);
            Store.Instance.AddProductToStore("C", 20);
            Store.Instance.AddProductToStore("D", 15);

            PromotionFactory.Instance.AddNewPromotionOne("A", 3, 130);
            PromotionFactory.Instance.AddNewPromotionOne("B", 2, 45);
            PromotionFactory.Instance.AddNewPromotionTwo("C", "D", 30);

            Cart cart1 = new Cart();

            cart1.AddPurchaseToCart("A", 1);
            cart1.AddPurchaseToCart("B", 1);
            cart1.AddPurchaseToCart("C", 1);

            Billing.Instance.Bill(cart1);
            Console.WriteLine("Scenario A");
            Console.WriteLine(Billing.Instance.FinalBill);

            Console.WriteLine("");
            Console.WriteLine("");
            Cart cart2 = new Cart();

            cart2.AddPurchaseToCart("A", 5);
            cart2.AddPurchaseToCart("B", 5);
            cart2.AddPurchaseToCart("C", 1);

            Billing.Instance.Bill(cart2);
            Console.WriteLine("Scenario B");
            Console.WriteLine(Billing.Instance.FinalBill);


            Console.WriteLine("");
            Console.WriteLine("");
            Cart cart3 = new Cart();

            cart3.AddPurchaseToCart("A", 3);
            cart3.AddPurchaseToCart("B", 5);
            cart3.AddPurchaseToCart("C", 1);
            cart3.AddPurchaseToCart("D", 1);

            Billing.Instance.Bill(cart3);
            Console.WriteLine("Scenario C");
            Console.WriteLine(Billing.Instance.FinalBill);
        }
    }
}
