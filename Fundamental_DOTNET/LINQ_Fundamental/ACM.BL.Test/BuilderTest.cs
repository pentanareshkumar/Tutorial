using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL.Test
{
    [TestClass]
    public class BuilderTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void BuildIntegerSequenceTest()
        {
            //Arrange
            var builder = new Builder();

            //Act
            var result = builder.BuildIntegerSequence();

            //Analyze
            foreach (var item in result)
            {
                TestContext.WriteLine(item.ToString());
            }

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuildStringSequenceTest()
        {
            //Arrange
            var builder = new Builder();

            //Act
            var result = builder.BuildStringSequence();

            //Analyze
            foreach (var item in result)
            {
                TestContext.WriteLine(item);
            }

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CompareSequenceTest()
        {
            //Arrange
            var builder = new Builder();

            //Act
            var result = builder.CompareSequence();

            //Analyze
            foreach (var item in result)
            {
                TestContext.WriteLine(item.ToString());
            }

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
