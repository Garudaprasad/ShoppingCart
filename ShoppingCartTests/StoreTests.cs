using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Tests
{
    [TestClass()]
    public class StoreTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            new PrivateType(typeof(Store)).SetStaticField("_instance", null);
        }

        [TestMethod()]
        public void AddProductToStoreTest_ProductAddition_Success()
        {
            Assert.AreEqual(Store.Instance.AddProductToStore("A", 50), true);

            Assert.AreEqual(Store.Instance.AllProducts.Count, 1);

            Assert.AreEqual(Store.Instance.AddProductToStore("B", 30), true);

            Assert.AreEqual(Store.Instance.AllProducts.Count, 2);

            Assert.AreEqual(Store.Instance.AddProductToStore("C", 20), true);

            Assert.AreEqual(Store.Instance.AllProducts.Count, 3);

            Assert.AreEqual(Store.Instance.AddProductToStore("D", 15), true);

            Assert.AreEqual(Store.Instance.AllProducts.Count, 4);

            Assert.AreEqual(Store.Instance.AllProducts[0].ProductPrice, 50);
        }
    }
}