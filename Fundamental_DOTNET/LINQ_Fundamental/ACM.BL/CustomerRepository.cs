using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class CustomerRepository
    {
        public Customer Find(List<Customer> customerList, int customerId)
        {
            Customer foundCustomer = null;

            //foreach (var c in customerList)
            //{
            //    if (c.CustomerId == customerId)
            //    {
            //        foundCustomer = c;
            //        break;
            //    }
            //}

            /*  customerList must implement IEnumerable interface ,
                return type of this query is IEnmerable of Customer*/

            /**** LINQ uses deffered Execution ****/
            //Query Syntax is defined
            //var query = from c in customerList
            //            where c.CustomerId == customerId
            //            select c;
            //Query is executed
            //foundCustomer = query.First();

            /*** Method Sysntax - Lambda Expression & Extension Method ***/
            //foundCustomer = customerList.FirstOrDefault(c => c.CustomerId == customerId);

            // 2nd item
            //foundCustomer = customerList.Where(c => c.CustomerId == customerId).Skip(1).FirstOrDefault();

            foundCustomer = customerList.FirstOrDefault(c =>
            {
                Debug.WriteLine(c.LastName);
                return c.CustomerId == customerId;
            });

            return foundCustomer;
        }

        public IEnumerable<string> GetNames(List<Customer> customerList)
        {
            return customerList.Select(c => c.FirstName + "," + c.LastName);
        }

        public dynamic GetNameAndEmail(List<Customer> customerList)
        {
            var result = customerList.Select(c => new { Name = c.FirstName + "," + c.LastName, c.EmailAddress });
            foreach (var item in result)
            {
                Console.WriteLine(item.Name + "," + item.EmailAddress);
            }
            return result;
        }

        //Join Statement
        public dynamic GetNamesAndType(List<Customer> customerList, List<CustomerType> customerTypeList)
        {
            var queryList = customerList.Join(customerTypeList,
                            c => c.CustomerTypeId,
                            ct => ct.CustomerTypeId,
                            (c, ct) => new
                            {
                                Name = c.FirstName + "," + c.LastName,
                                CustomerTypeName = ct.TypeName
                            });
            foreach (var item in queryList)
            {
                Console.WriteLine(item.Name + "," + item.CustomerTypeName);
            }

            return queryList;
        }
        public List<Customer> Retrieve()
        {
            InvoiceRepository invoiceRepository = new InvoiceRepository();

            List<Customer> customerList = new List<Customer>{
                new Customer()
                {
                    CustomerId = 1,
                    FirstName = "Naresh",
                    LastName ="Kumar",
                    EmailAddress="Naresh.Kumar@gmail.com",
                    CustomerTypeId =1,
                    InvoiceList = invoiceRepository.Retrieve(1)
                },
                new Customer()
                    {
                    CustomerId = 2,
                    FirstName = "Srikant",
                    LastName ="Kumar",
                    EmailAddress="Srikant.Kumar@gmail.com",
                    CustomerTypeId =1,
                    InvoiceList = invoiceRepository.Retrieve(2)
                    },
                new Customer()
                {
                CustomerId = 3,
                FirstName = "Sriram",
                LastName ="Kumar",
                EmailAddress="Sriram.Kumar@gmail.com",
                CustomerTypeId =null,
                InvoiceList = invoiceRepository.Retrieve(3)
                },
                new Customer()
                    {
                    CustomerId = 4,
                    FirstName = "Rajesh",
                    LastName ="Kumar",
                    EmailAddress="Rajesh.Kumar@gmail.com",
                    CustomerTypeId =2,
                    InvoiceList = invoiceRepository.Retrieve(4)
                    }
            };
            return customerList;
        }

        public IEnumerable<Customer> SortByName(List<Customer> customerList)
        {
            var result = customerList.OrderBy(c => c.LastName).ThenBy(c => c.FirstName);

            return result;
        }

        public IEnumerable<Customer> SortByNameInReverse(List<Customer> customerList)
        {
            return customerList.OrderByDescending(c => c.LastName).ThenByDescending(c => c.FirstName);
        }

        public IEnumerable<Customer> SortyByType(List<Customer> customerList)
        {
            // it will return null values first then remaining..
            return customerList.OrderBy(c => c.CustomerTypeId);
        }

        //Parent, Child relationship
        public IEnumerable<Customer> GetOverdueCustomers(List<Customer> customerList)
        {
            // Several Issues while working with Select operator in Parent Child relation
            // Dificult to manage IEnumerable<IEnumerable<Invoice>>
            //var query = customerList
            //    .Select(c => c.InvoiceList.Where(i => (i.IsPaid ?? false) == false));

            var query = customerList.SelectMany(c => c.InvoiceList
                                    .Where(i => (i.IsPaid ?? false) == false)
                                    , (c, i) => c).Distinct();
            return query;
        }

        public IEnumerable<KeyValuePair<string,decimal>> GetInvoiceTotalByCustomerType(List<Customer> customerList,
                                                     List<CustomerType> customerTypeList)
        {
            var customerTypeQuery = customerList.Join(customerTypeList,
                                                    cus => cus.CustomerTypeId,
                                                    cusType => cusType.CustomerTypeId,
                                                    (cus, cusType) => new
                                                    {
                                                        CustomerInstance = cus,
                                                        CustomerTypeName = cusType.TypeName
                                                    });
            var query = customerTypeQuery.GroupBy(c => c.CustomerTypeName,
                                            c => c.CustomerInstance.InvoiceList.Sum(i => i.TotalAmount),
                                            (groupKey, invTotal) => new KeyValuePair<string, decimal>(groupKey, invTotal.Sum()) 
                                           );
            foreach (var item in query)
            {
                Console.WriteLine(item.Key + ":" + item.Value);
            }
            return query;
        }
    }
}
