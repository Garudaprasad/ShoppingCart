using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProblemStatement1.Tests
{
    [TestClass()]
    public class CartTests
    {

        [TestInitialize]
        public void TestInitialize()
        {
            new PrivateType(typeof(Store)).SetStaticField("_instance", null);
        }

        [TestMethod()]
        public void AddPurchaseToCart_NoProducts_ProductAddition_Failed()
        {
            Cart cart = new Cart();
            Assert.AreEqual(cart.AddPurchaseToCart("A", 12), false);
            Assert.AreEqual(cart.AllPurchases.Count, 0);
        }

        [TestMethod()]
        public void AddPurchaseToCart_WithProducts_ProductAdded_Success()
        {
            Store.Instance.AddProductToStore("A", 12);
            Cart cart = new Cart();
            Assert.AreEqual(cart.AddPurchaseToCart("A", 10), true);

            Assert.AreEqual(cart.AllPurchases.Count, 1);
            Assert.AreEqual(cart.AllPurchases[0].ProductName, "A");
            Assert.AreEqual(cart.AllPurchases[0].Quantity, 10);
            Assert.AreEqual(cart.AllPurchases[0].Prod.ProductPrice, 12);
        }

        [TestMethod()]
        public void AddPurchaseToCart_WithPurchase_AddQuantity_Success()
        {
            Store.Instance.AddProductToStore("A", 12);
            Cart cart = new Cart();
            Assert.AreEqual(cart.AddPurchaseToCart("A", 10), true);

            Assert.AreEqual(cart.AllPurchases.Count, 1);
            Assert.AreEqual(cart.AllPurchases[0].ProductName, "A");
            Assert.AreEqual(cart.AllPurchases[0].Quantity, 10);
            Assert.AreEqual(cart.AllPurchases[0].Prod.ProductPrice, 12);

            cart.AddPurchaseToCart("A", 10);
            Assert.AreEqual(cart.AllPurchases[0].Quantity, 20);
        }
    }
}