using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication10.Models;

namespace UnitTestProject1.Tests
{
    /// <summary>
    /// 注解testclass
    /// </summary>
    [TestClass]
    public class UnitTest1
    {

        private IDiscountHelper getTestObject()
        {
            return new MinimumDiscountHelper();
        }

        /// <summary>
        /// 注解testmethod
        /// </summary>
        [TestMethod]
        public void DiscountTest()
        {
            IDiscountHelper target = getTestObject();
            decimal total = 200;

            var discountedTotal = target.ApplyDiscount(total);

            Assert.AreEqual(total * 0.9m, discountedTotal);

        }
    }
}
