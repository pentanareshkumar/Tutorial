using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForUnitTesting;

namespace MSUnitTest
{
    [TestClass]
    public class MSTestExample
    {
        [TestMethod]
        public void Test_Trending_MSTest_OK()
        {
            var result = TrendingRunner.WhatsTrending(1);

            Assert.AreEqual("Paul Walker", result);

        }
    }
}
