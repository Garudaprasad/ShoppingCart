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
    }
}