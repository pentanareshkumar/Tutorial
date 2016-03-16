using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL.Test
{
    [TestClass]
    public class InvoiceRepositoryTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void CalculateTotalAmountInvoicedTest()
        {
            //Arrange
            var invoiceRepo = new InvoiceRepository();
            var invoiceList = invoiceRepo.Retrieve();

            //Act
            var result = invoiceRepo.CalculateTotalAmountInvoiced(invoiceList);

            TestContext.WriteLine(result.ToString());
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CalculateTotalNoOfUnitsSoldTest()
        {
            //Arrange
            var invoiceRepo = new InvoiceRepository();
            var invoiceList = invoiceRepo.Retrieve();

            //Act
            var result = invoiceRepo.CalculateTotalNoOfUnitsSold(invoiceList);

            TestContext.WriteLine(result.ToString());
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetInvoiceTotalByIsPaidTest()
        {
            //Arrange
            var invoiceRepo = new InvoiceRepository();
            var invoiceList = invoiceRepo.Retrieve();

            //Act
            var result = invoiceRepo.GetInvoiceTotalByIsPaid(invoiceList);

        }

        [TestMethod]
        public void GetInvoiceTotalByIsPaidAndMonthTest()
        {
            //Arrange
            var invoiceRepo = new InvoiceRepository();
            var invoiceList = invoiceRepo.Retrieve();

            //Act
            var result = invoiceRepo.GetInvoiceTotalByIsPaidAndMonth(invoiceList);
        }

        
    }
}
