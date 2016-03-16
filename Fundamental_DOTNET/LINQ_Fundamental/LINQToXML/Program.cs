using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQToXML
{
    /*
     *  LINQ to XML provides an in-memory XML programming interface that leverages the .NET Language-Integrated Query (LINQ) Framework.
     *  IEnumerable<T> can be used to query the XML data and for this standard query the operators show up as extension methods on 
        any object that implements IEnumerable<T> and can be invoked like any other method.
            Where
            Select
            SelectMany
            OrderBy
            GroupBy
     *  Load and Serialize XML from files or streams.
     *  XML to files or streams.
     *  Create XML trees from scratch using functional construction.
     *  Query XML trees using LINQ queries.
     *  Manipulate in-memory XML trees.
     *  Validate XML trees using XSD.
     *  Use a combination of these features to transform XML trees from one shape into another
     
     */
    class Program
    {
        static void Main(string[] args)
        {
            /* Create a XML document using hard coded values*/
            //CreateXML();

            /* Create a XML document from a Source*/
            //CreateXMLFromSource();

            /* Querying using xml document using LINQ to XML*/
            //LoadCustomerFromXML();

            /* Inserting a new Record */
            //InsertRecord();

            /* Update a record */
            //UpdateRecord();

            /* Delete a record */
            //DeleteRecord();

            Console.ReadLine();
        }

        private static void DeleteRecord()
        {
            XDocument xdoc = XDocument.Load(@"E:\Fundamental_DOTNET\LINQ_Fundamental\LINQToXML\CustomersDetail.xml");

            xdoc.Element("Customers").Elements("Customer")
                .Where(x => x.Attribute("CustID").Value == "1000").SingleOrDefault()
                .Remove();
            
            xdoc.Save(@"E:\Fundamental_DOTNET\LINQ_Fundamental\LINQToXML\CustomersDetail.xml");
        }

        private static void UpdateRecord()
        {
            XDocument xdoc = XDocument.Load(@"E:\Fundamental_DOTNET\LINQ_Fundamental\LINQToXML\CustomersDetail.xml");
            xdoc.Element("Customers").Elements("Customer")
                .Where(x => x.Attribute("CustID").Value == "1001").SingleOrDefault()
                .SetElementValue("MobileNo", "8050005830");

            xdoc.Save(@"E:\Fundamental_DOTNET\LINQ_Fundamental\LINQToXML\CustomersDetail.xml");
        }

        private static void InsertRecord()
        {
            XDocument xdoc = XDocument.Load(@"E:\Fundamental_DOTNET\LINQ_Fundamental\LINQToXML\CustomersDetail.xml");

            xdoc.Element("Customers").Add(
                new XElement("Customer", new XAttribute("CustID", 1007),
                new XElement("Name", "Srikant"),
                new XElement("MobileNo", "987654321"),
                new XElement("Location", "Chennai"),
                new XElement("Address", "IIT Madras")
                ));
            
            xdoc.Element("Customers").AddFirst(
               new XElement("Customer", new XAttribute("CustID", 1000),
               new XElement("Name", "Bob"),
               new XElement("MobileNo", "9922823460"),
               new XElement("Location", "London"),
               new XElement("Address", "27th streat London")
                ));
            
            xdoc.Element("Customers").Elements("Customer")
            .Where(X => X.Attribute("CustID").Value == "1003").SingleOrDefault()
            .AddBeforeSelf(
                  new XElement("Customer", new XAttribute("CustID", 2000),
                  new XElement("Name", "David"),
                  new XElement("MobileNo", "9921123460"),
                  new XElement("Location", "London"),
                  new XElement("Address", "87th streat London")
                ));

            xdoc.Save(@"E:\Fundamental_DOTNET\LINQ_Fundamental\LINQToXML\CustomersDetail.xml");
        }

        public static void CreateXML()
        {
            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),

                new XComment("LINQ to XML Demo"),

                new XElement("Customers",
                    new XElement("Customer", new XAttribute("CustID", 1001),
                        new XElement("Name", "Naresh"),
                        new XElement("MobileNo", "9036205830"),
                        new XElement("Location", "Bangalore"),
                        new XElement("Address", "Marathahalli")
                        ),
                    new XElement("Customer", new XAttribute("CustID", 1002),
                        new XElement("Name", "Sateesh"),
                        new XElement("MobileNo", "9035306830"),
                        new XElement("Location", "Bangalore"),
                        new XElement("Address", "Channasandra")
                        ),
                    new XElement("Customer", new XAttribute("CustID", 1003),
                        new XElement("Name", "Suman"),
                        new XElement("MobileNo", "9844125159"),
                        new XElement("Location", "Yeswantpur"),
                        new XElement("Address", "Mattikeri")
                        ),
                    new XElement("Customer", new XAttribute("CustID", 1004),
                        new XElement("Name", "Satya"),
                        new XElement("MobileNo", "9087654332"),
                        new XElement("Location", "Bangalore"),
                        new XElement("Address", "Domluru")
                        ),
                     new XElement("Customer", new XAttribute("CustID", 1005),
                        new XElement("Name", "Suresh"),
                        new XElement("MobileNo", "9035306830"),
                        new XElement("Location", "Hyderabad"),
                        new XElement("Address", "Nallakunta")
                        ),
                    new XElement("Customer", new XAttribute("CustID", 1006),
                        new XElement("Name", "Rajesh"),
                        new XElement("MobileNo", "99877665544"),
                        new XElement("Location", "Hyderabad"),
                        new XElement("Address", "Madhapura")
                        )
                    ));
            xmlDocument.Save(@"E:\Fundamental_DOTNET\LINQ_Fundamental\LINQToXML\CustomersDetail.xml");
        }

        public static void CreateXMLFromSource()
        {
            //Source
            List<Customer> customersList = new List<Customer> { 
                                            new Customer(){
                                                CustID= 1001,
                                                Name="Naresh",
                                                MobileNo=9035306830,
                                                Location = "Bangalore",
                                                Address ="Marathahalli"
                                            },
                                            new Customer(){
                                                CustID= 1002,
                                                Name="Sateesh",
                                                MobileNo=9035306830,
                                                Location = "Bangalore",
                                                Address ="Channasandra"
                                            },
                                            new Customer(){
                                                CustID= 1003,
                                                Name="Suman",
                                                MobileNo=9844125159,
                                                Location = "Bangalore",
                                                Address ="Mattikeri"
                                            },
                                            new Customer(){
                                                CustID= 1004,
                                                Name="Satya",
                                                MobileNo=9087654332,
                                                Location = "Bangalore",
                                                Address ="Domluru"
                                            }
                                        };
            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("LINQ To XML Demo"),
                new XElement("Customers",
                    from customer in customersList
                    select new XElement("Customer", new XAttribute("CustID", customer.CustID),
                            new XElement("Name", customer.Name),
                            new XElement("MobileNo", customer.MobileNo),
                            new XElement("Location", customer.Location),
                            new XElement("Address", customer.Address))
                    ));
            xmlDocument.Save(@"E:\Fundamental_DOTNET\LINQ_Fundamental\LINQToXML\CustomersDetailFromSource.xml");

        }

        public class Customer
        {
            public int CustID { get; set; }
            public string Name { get; set; }
            public long MobileNo { get; set; }
            public string Location { get; set; }
            public string Address { get; set; }

            public override string ToString()
            {
                return string.Format("{0} \t {1} \t\t {2} \t {3} \t {4}", CustID, Name, MobileNo, Location, Address);
            }
        }

        public static void LoadCustomerFromXML()
        {
            IEnumerable<Customer> customerList = from customer in
                                                     XDocument.Load(@"E:\Fundamental_DOTNET\LINQ_Fundamental\LINQToXML\CustomersDetail.xml").Descendants("Customer")
                                                 select new Customer()
                                                 {
                                                     CustID = int.Parse(customer.Attribute("CustID").Value),
                                                     Name = customer.Element("Name").Value.ToString(),
                                                     MobileNo = long.Parse(customer.Element("MobileNo").Value),
                                                     Location = customer.Element("Location").Value.ToString(),
                                                     Address = customer.Element("Address").Value.ToString()
                                                 };
            Console.WriteLine("CustID \t Name \t\t MobileNo \t Location \t Address");

            foreach (var customer in customerList)
            {
                Console.WriteLine(customer.ToString());
            }
        }
    }


}
