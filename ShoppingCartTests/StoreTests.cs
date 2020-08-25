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

        [TestMethod()]
        public void AddProductToStoreTest_SameProductAddition_Failed()
        {
            Assert.AreEqual(Store.Instance.AddProductToStore("A", 50), true);

            Assert.AreEqual(Store.Instance.AllProducts.Count, 1);

            Assert.AreEqual(Store.Instance.AddProductToStore("B", 30), true);

            Assert.AreEqual(Store.Instance.AllProducts.Count, 2);

            Assert.AreEqual(Store.Instance.AddProductToStore("C", 20), true);

            Assert.AreEqual(Store.Instance.AllProducts.Count, 3);

            Assert.AreEqual(Store.Instance.AddProductToStore("D", 15), true);

            Assert.AreEqual(Store.Instance.AllProducts.Count, 4);

            Assert.AreEqual(Store.Instance.AddProductToStore("A", 20), false);

            Assert.AreEqual(Store.Instance.AllProducts.Count, 4);

            Assert.AreEqual(Store.Instance.AllProducts[0].ProductPrice, 50);
        }

        [TestMethod()]
        public void AddProductToStoreTest_EmptyNameProductAddition_Failed()
        {
            Assert.AreEqual(Store.Instance.AddProductToStore("", 50), false);

            Assert.AreEqual(Store.Instance.AllProducts.Count, 0);

            Assert.AreEqual(Store.Instance.AddProductToStore(string.Empty, 50), false);

            Assert.AreEqual(Store.Instance.AllProducts.Count, 0);
        }

        [TestMethod()]
        public void AddProductToStoreTest_PriceLessThanOrEqualToZeroProductAddition_Failed()
        {
            Assert.AreEqual(Store.Instance.AddProductToStore("A", -50), false);

            Assert.AreEqual(Store.Instance.AllProducts.Count, 0);

            Assert.AreEqual(Store.Instance.AddProductToStore("A", 0), false);

            Assert.AreEqual(Store.Instance.AllProducts.Count, 0);
        }

        [TestMethod()]
        public void RemoveProductFromStore_ExistingProductDelete_Success()
        {
            Assert.AreEqual(Store.Instance.AddProductToStore("A", 50), true);

            Assert.AreEqual(Store.Instance.AllProducts.Count, 1);

            Assert.AreEqual(Store.Instance.AddProductToStore("B", 30), true);

            Assert.AreEqual(Store.Instance.AllProducts.Count, 2);

            Assert.AreEqual(Store.Instance.AddProductToStore("C", 20), true);

            Assert.AreEqual(Store.Instance.AllProducts.Count, 3);

            Assert.AreEqual(Store.Instance.AddProductToStore("D", 15), true);

            Assert.AreEqual(Store.Instance.AllProducts.Count, 4);


            int prodCount = Store.Instance.AllProducts.Count;
            Assert.AreEqual(Store.Instance.RemoveProductFromStore(Store.Instance.AllProducts[0]), true);
            Assert.AreEqual(Store.Instance.AllProducts.Count, prodCount-1);
        }

        [TestMethod()]
        public void RemoveProductFromStore_NonExistingProductDelete_Fail()
        {
            Assert.AreEqual(Store.Instance.AddProductToStore("A", 50), true);

            Assert.AreEqual(Store.Instance.AllProducts.Count, 1);

            Assert.AreEqual(Store.Instance.AddProductToStore("B", 30), true);

            Assert.AreEqual(Store.Instance.AllProducts.Count, 2);

            Assert.AreEqual(Store.Instance.AddProductToStore("C", 20), true);

            Assert.AreEqual(Store.Instance.AllProducts.Count, 3);

            Assert.AreEqual(Store.Instance.AddProductToStore("D", 15), true);

            Assert.AreEqual(Store.Instance.AllProducts.Count, 4);


            int prodCount = Store.Instance.AllProducts.Count;
            Assert.AreEqual(Store.Instance.RemoveProductFromStore(new Product("F", 12)), false);
            Assert.AreEqual(Store.Instance.AllProducts.Count, prodCount);
        }
    }
}