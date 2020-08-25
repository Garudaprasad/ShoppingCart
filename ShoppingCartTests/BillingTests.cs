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
    }
}