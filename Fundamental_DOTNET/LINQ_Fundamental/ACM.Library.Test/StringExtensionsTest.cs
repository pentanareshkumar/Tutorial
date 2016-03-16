using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.Library.Test
{
    [TestClass]
    public class StringExtensionsTest
    {
        [TestMethod]
        public void ConvertToTitleCaseTest()
        {
            //Arrange
            string source = "hello naresh, how are you ?";
            string expected = "Hello Naresh, How Are You ?";

            //Act
            //var result = StringExtensions.ConvertToTitleCase(source);
            var result = source.ConvertToTitleCase();

            //Assets
            Assert.IsNotNull(result);
            Assert.AreEqual(result, expected);
        }
    }
}
