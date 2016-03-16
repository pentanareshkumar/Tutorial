using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class InvoiceRepository
    {
        public List<Invoice> Retrieve(int customerId)
        {
            List<Invoice> invoiceList = new List<Invoice>
            { new Invoice()
                {
                    InvoiceId = 1,
                    CustomerId = 1,
                    InvoiceDate = new DateTime(2015,6,20),
                    DueDate = new DateTime(2015,8,29),
                    IsPaid = null,
                    Amount = 199.99M,
                    NumberOfUnits = 20,
                    DiscountPercent=0M
                },
                new Invoice()
                {
                    InvoiceId = 3,
                    CustomerId = 2,
                    InvoiceDate = new DateTime(2015,7,25),
                    DueDate = new DateTime(2015,8,25),
                    IsPaid = null,
                    Amount = 98.50M,
                    NumberOfUnits = 10,
                    DiscountPercent=10M
                },
                new Invoice()
                {
                    InvoiceId = 2,
                    CustomerId = 1,
                    InvoiceDate = new DateTime(2015,7,20),
                    DueDate = new DateTime(2015,8,20),
                    IsPaid = null,
                    Amount = 250M,
                    NumberOfUnits = 25,
                    DiscountPercent=10M
                },
                new Invoice()
                {
                    InvoiceId = 4,
                    CustomerId = 3,
                    InvoiceDate = new DateTime(2015,7,1),
                    DueDate = new DateTime(2015,9,1),
                    IsPaid = true,
                    Amount = 20M,
                    NumberOfUnits = 2,
                    DiscountPercent=15M
                },
                new Invoice()
                {
                    InvoiceId = 5,
                    CustomerId = 1,
                    InvoiceDate = new DateTime(2015,8,20),
                    DueDate = new DateTime(2015,9,29),
                    IsPaid = true,
                    Amount = 225M,
                    NumberOfUnits = 22,
                    DiscountPercent=10M
                },
                new Invoice()
                {
                    InvoiceId = 6,
                    CustomerId = 2,
                    InvoiceDate = new DateTime(2015,8,20),
                    DueDate = new DateTime(2015,8,20),
                    IsPaid = false,
                    Amount = 75M,
                    NumberOfUnits = 8,
                    DiscountPercent=0M
                },
                new Invoice()
                {
                    InvoiceId = 7,
                    CustomerId = 3,
                    InvoiceDate = new DateTime(2015,8,1),
                    DueDate = new DateTime(2015,9,1),
                    IsPaid = true,
                    Amount = 75M,
                    NumberOfUnits = 7,
                    DiscountPercent=0M
                },
                new Invoice()
                {
                    InvoiceId = 8,
                    CustomerId = 4,
                    InvoiceDate = new DateTime(2015,8,1),
                    DueDate = new DateTime(2015,9,1),
                    IsPaid = true,
                    Amount = 75M,
                    NumberOfUnits = 7,
                    DiscountPercent=0M
                }
            };

            var filteredList = invoiceList.Where(i => i.CustomerId == customerId).ToList();
            return filteredList;
        }

        public List<Invoice> Retrieve()
        {
            List<Invoice> invoiceList = new List<Invoice>
            { new Invoice()
                {
                    InvoiceId = 1,
                    CustomerId = 1,
                    InvoiceDate = new DateTime(2015,6,20),
                    DueDate = new DateTime(2015,8,29),
                    IsPaid = null,
                    Amount = 199.99M,
                    NumberOfUnits = 20,
                    DiscountPercent=0M
                },
                new Invoice()
                {
                    InvoiceId = 3,
                    CustomerId = 2,
                    InvoiceDate = new DateTime(2015,7,25),
                    DueDate = new DateTime(2015,8,25),
                    IsPaid = null,
                    Amount = 98.50M,
                    NumberOfUnits = 10,
                    DiscountPercent=10M
                },
                new Invoice()
                {
                    InvoiceId = 2,
                    CustomerId = 1,
                    InvoiceDate = new DateTime(2015,7,20),
                    DueDate = new DateTime(2015,8,20),
                    IsPaid = null,
                    Amount = 250M,
                    NumberOfUnits = 25,
                    DiscountPercent=10M
                },
                new Invoice()
                {
                    InvoiceId = 4,
                    CustomerId = 3,
                    InvoiceDate = new DateTime(2015,7,1),
                    DueDate = new DateTime(2015,9,1),
                    IsPaid = true,
                    Amount = 20M,
                    NumberOfUnits = 2,
                    DiscountPercent=15M
                },
                new Invoice()
                {
                    InvoiceId = 5,
                    CustomerId = 1,
                    InvoiceDate = new DateTime(2015,8,20),
                    DueDate = new DateTime(2015,9,29),
                    IsPaid = true,
                    Amount = 225M,
                    NumberOfUnits = 22,
                    DiscountPercent=10M
                },
                new Invoice()
                {
                    InvoiceId = 6,
                    CustomerId = 2,
                    InvoiceDate = new DateTime(2015,8,20),
                    DueDate = new DateTime(2015,8,20),
                    IsPaid = false,
                    Amount = 75M,
                    NumberOfUnits = 8,
                    DiscountPercent=0M
                },
                new Invoice()
                {
                    InvoiceId = 7,
                    CustomerId = 3,
                    InvoiceDate = new DateTime(2015,8,1),
                    DueDate = new DateTime(2015,9,1),
                    IsPaid = true,
                    Amount = 75M,
                    NumberOfUnits = 7,
                    DiscountPercent=0M
                },
                new Invoice()
                {
                    InvoiceId = 8,
                    CustomerId = 4,
                    InvoiceDate = new DateTime(2015,8,1),
                    DueDate = new DateTime(2015,9,1),
                    IsPaid = true,
                    Amount = 75M,
                    NumberOfUnits = 7,
                    DiscountPercent=0M
                }
            };

            return invoiceList;
        }

        public decimal CalculateTotalAmountInvoiced(List<Invoice> invoiceList)
        {
            return invoiceList.Sum(inv => inv.TotalAmount);
        }

        public int CalculateTotalNoOfUnitsSold(List<Invoice> invoiceList)
        {
            return invoiceList.Sum(inv => inv.NumberOfUnits);
        }

        public dynamic GetInvoiceTotalByIsPaid(List<Invoice> invoiceList)
        {
            var query = invoiceList.GroupBy(inv => inv.IsPaid ?? false,
                                            inv => inv.TotalAmount,
                                            (groupKey, invTotal) => new
                                            {
                                                key = groupKey,
                                                InvoiceAmount = invTotal.Sum()
                                            });
            foreach (var item in query)
            {
                Console.WriteLine(item.key + ":" + item.InvoiceAmount.ToString());
            }
            return query;
        }

        public dynamic GetInvoiceTotalByIsPaidAndMonth(List<Invoice> invoiceList)
        {
            var query = invoiceList.GroupBy(inv => new
                                    {
                                        IsPaid = inv.IsPaid ?? false,
                                        InvoiceMonth = inv.InvoiceDate.ToString("MMMM")
                                    },
                                    inv => inv.TotalAmount,
                                    (groupkey, invTotal) => new
                                    {
                                        key = groupkey,
                                        invoiceAmount = invTotal.Sum()
                                    });
            foreach (var item in query)
            {
                Console.WriteLine(item.key.IsPaid + "/" + item.key.InvoiceMonth + ":" + item.invoiceAmount);
            }

            return query;
        }

        
    }
}
