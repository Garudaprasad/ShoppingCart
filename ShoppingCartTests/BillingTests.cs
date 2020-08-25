using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemStatement1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemStatement1.Tests
{
    [TestClass()]
    public class BillingTests
    {

        [TestInitialize]
        public void TestInitialize()
        {
            new PrivateType(typeof(Store)).SetStaticField("_instance", null);
            new PrivateType(typeof(PromotionFactory)).SetStaticField("_instance", null);
            new PrivateType(typeof(Billing)).SetStaticField("_instance", null);
        }

        [TestMethod()]
        public void BillTest_EmptyCart_Success()
        {
            Billing.Instance.Bill(new Cart());
            Assert.AreEqual(Billing.Instance.BillTotal, 0);
        }

        [TestMethod()]
        public void BillTest_FilledCart_NoPromotions_Success()
        {
            Store.Instance.AddProductToStore("A", 50);
            Store.Instance.AddProductToStore("B", 30);
            Store.Instance.AddProductToStore("C", 20);
            Store.Instance.AddProductToStore("D", 15);

            Cart cart1 = new Cart();

            cart1.AddPurchaseToCart("A", 5);
            cart1.AddPurchaseToCart("B", 5);
            cart1.AddPurchaseToCart("C", 5);
            cart1.AddPurchaseToCart("D", 5);

            Billing.Instance.Bill(cart1);
            Assert.AreEqual(Billing.Instance.BillTotal, 575);
        }


        [TestMethod()]
        public void BillTest_FilledCart_WithPromotions_Success()
        {
            Store.Instance.AddProductToStore("A", 50);
            Store.Instance.AddProductToStore("B", 30);
            Store.Instance.AddProductToStore("C", 20);
            Store.Instance.AddProductToStore("D", 15);
            Store.Instance.AddProductToStore("E", 10);

            PromotionFactory.Instance.AddNewPromotionOne("A", 3, 130);
            PromotionFactory.Instance.AddNewPromotionOne("B", 2, 45);
            PromotionFactory.Instance.AddNewPromotionTwo("C", "D", 30);

            Cart cart1 = new Cart();

            cart1.AddPurchaseToCart("A", 1);
            cart1.AddPurchaseToCart("B", 1);
            cart1.AddPurchaseToCart("C", 1);

            Billing.Instance.Bill(cart1);
            Assert.AreEqual(Billing.Instance.BillTotal, 100);


            Cart cart2 = new Cart();

            cart2.AddPurchaseToCart("A", 5);
            cart2.AddPurchaseToCart("B", 5);
            cart2.AddPurchaseToCart("C", 1);

            Billing.Instance.Bill(cart2);
            Assert.AreEqual(Billing.Instance.BillTotal, 370);



            Cart cart3 = new Cart();

            cart3.AddPurchaseToCart("A", 3);
            cart3.AddPurchaseToCart("B", 5);
            cart3.AddPurchaseToCart("C", 1);
            cart3.AddPurchaseToCart("D", 1);

            Billing.Instance.Bill(cart3);
            Assert.AreEqual(Billing.Instance.BillTotal, 280);


            Cart cart4 = new Cart();

            cart4.AddPurchaseToCart("A", 5);
            cart4.AddPurchaseToCart("B", 5);
            cart4.AddPurchaseToCart("D", 1);

            Billing.Instance.Bill(cart4);
            Assert.AreEqual(Billing.Instance.BillTotal, 365);


            Cart cart5 = new Cart();

            cart5.AddPurchaseToCart("A", 5);
            cart5.AddPurchaseToCart("B", 5);
            cart5.AddPurchaseToCart("C", 1);
            cart5.AddPurchaseToCart("D", 2);

            Billing.Instance.Bill(cart5);
            Assert.AreEqual(Billing.Instance.BillTotal, 395);


            Cart cart6 = new Cart();

            cart6.AddPurchaseToCart("A", 5);
            cart6.AddPurchaseToCart("B", 5);
            cart6.AddPurchaseToCart("C", 2);
            cart6.AddPurchaseToCart("D", 1);

            Billing.Instance.Bill(cart6);
            Assert.AreEqual(Billing.Instance.BillTotal, 400);


            Cart cart7 = new Cart();

            cart7.AddPurchaseToCart("A", 5);
            cart7.AddPurchaseToCart("B", 5);
            cart7.AddPurchaseToCart("C", 2);
            cart7.AddPurchaseToCart("D", 1);
            cart7.AddPurchaseToCart("E", 1);

            Billing.Instance.Bill(cart7);
            Assert.AreEqual(Billing.Instance.BillTotal, 410);
        }
    }
}