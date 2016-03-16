using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Test
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void FindTestExistingCustomer()
        {
            //Arrange
            CustomerRepository customerRepo = new CustomerRepository();
            var customerList = customerRepo.Retrieve();

            //Act
            var result = customerRepo.Find(customerList, 1);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.CustomerId);
            Assert.AreEqual("Naresh", result.FirstName);
            Assert.AreEqual("Kumar", result.LastName);
            Assert.AreEqual("Naresh.Kumar@gmail.com", result.EmailAddress);
        }

        [TestMethod]
        public void FindTestNotFound()
        {
            //Arrange
            CustomerRepository customerRepo = new CustomerRepository();
            var customerList = customerRepo.Retrieve();

            //Act
            var result = customerRepo.Find(customerList, 42);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SortByNameTest()
        {
            //Arrange
            CustomerRepository customerRepo = new CustomerRepository();
            var customerList = customerRepo.Retrieve();

            //Act
            var result = customerRepo.SortByName(customerList);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.First().FirstName, "Naresh");
        }

        [TestMethod]
        public void SortyByTypeTest()
        {
            //Arrange
            CustomerRepository customerRepo = new CustomerRepository();
            var customerList = customerRepo.Retrieve();

            //Act
            var result = customerRepo.SortyByType(customerList);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.First().FirstName, "Sriram");
        }

        [TestMethod]
        public void GetNamesTest()
        {
            //Arrange
            CustomerRepository customerRepo = new CustomerRepository();
            var customerList = customerRepo.Retrieve();
            var customerNames = customerRepo.GetNames(customerList);

            //Act
            foreach (var item in customerNames)
            {
                TestContext.WriteLine(item);
            }
            //Assert
            Assert.IsNotNull(customerNames);
        }

        [TestMethod]
        public void GetNameAndEmailTest()
        {
            //Arange
            CustomerRepository customerRepo = new CustomerRepository();
            var customerList = customerRepo.Retrieve();

            //Act
            var customerNameAndEmail = customerRepo.GetNameAndEmail(customerList);

        }

        [TestMethod]
        public void GetNamesAndTypeTest()
        {
            //Arange
            CustomerRepository customerRepo = new CustomerRepository();
            var customerList = customerRepo.Retrieve();

            CustomerTypeRepository customerTypeRepo = new CustomerTypeRepository();
            var customerTypeList = customerTypeRepo.Retrieve();

            //Act
            var customerNamesAndType = customerRepo.GetNamesAndType(customerList, customerTypeList);

        }

        [TestMethod]
        public void GetOverdueCustomersTest()
        {
            //Arange
            CustomerRepository customerRepo = new CustomerRepository();
            var customerList = customerRepo.Retrieve();

            //Act
            var query = customerRepo.GetOverdueCustomers(customerList);

            foreach (var item in query)
            {
                TestContext.WriteLine(item.FirstName + "," + item.LastName);
            }
            //Assert
            Assert.IsNotNull(query);
        }

        [TestMethod]
        public void GetInvoiceTotalByCustomerTypeTest()
        {
            //Arange
            CustomerRepository customerRepo = new CustomerRepository();
            var customerList = customerRepo.Retrieve();

            CustomerTypeRepository customerTypeRepo = new CustomerTypeRepository();
            var customerTypeList = customerTypeRepo.Retrieve();
            //Act
            var result = customerRepo.GetInvoiceTotalByCustomerType(customerList, customerTypeList);

        }
    }
}
