using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Predicate
{
    /*
     *  What is a predicate delegate?
        A predicate delegate is a delegate with the following signature:
        Return type - bool
        Argument type - generic
        
     *  So, a predicate delegate is a delegate which points to a boolean function that returns true or false and 
        takes a generic type as an argument. A predicate delegate thus is a delegate which is capable of taking any custom type as an argument. 
        This makes it quite useful because what we get as a result is a generic delegate. 
        The bool function that it points to has logic to evaluate any condition and return true/false accordingly.
      
     *  The most common use of a predicate delegate is for searching items in a collection.
        Because a predicate delegate is a delegate of type T or generic, it is most useful when searching items in a generic collection.
     */
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>{
                                         new Employee()
                                            {
                                                FirstName ="Naresh", 
                                                LastName ="Kumar", 
                                                Designation ="Senior Software Associate L1" 
                                            },
                                         new Employee()
                                            {
                                                FirstName ="Sateesh", 
                                                LastName ="Chandolu", 
                                                Designation ="Senior Software Associate L1" 
                                            },
                                        new Employee()
                                            {
                                                FirstName ="Suman", 
                                                LastName ="Pulavarthy", 
                                                Designation ="Senior Software Associate L2" 
                                            },
                                        new Employee()
                                            {
                                                FirstName ="Satya", 
                                                LastName ="Singh", 
                                                Designation ="Software Associate QA L2" 
                                            }
                                        };


            // Method #1 - The traditional way of doing it
            Predicate<Employee> pred = new Predicate<Employee>(Employee.EmpSearch);
            Employee foundEmp1 = empList.Find(pred);
            Console.WriteLine("Employee Found {0}", foundEmp1.FirstName);

            //Method #2 - Using anonymous functions
            Employee foundEmp2 = empList.Find(delegate(Employee e) {
                if (e.FirstName == "Naresh")
                    return true;
                else
                    return false;
            });
            Console.WriteLine("Employee Found {0}", foundEmp2.FirstName);

            // Method #3 - Using a lambda expression
            Employee foundEmp3 = empList.Find((e) => { return (e.FirstName == "Naresh"); });
            Console.WriteLine("Employee Found {0}", foundEmp3.FirstName);

            // Searching a list of employees
            List<Employee> empFirstLetterSList = empList.FindAll( (e) => { return (e.FirstName.StartsWith("S"));});
            foreach (var item in empFirstLetterSList)
            {
                Console.WriteLine("Employee Found with First Name first letter S {0}", item.FirstName);
            }
            Console.ReadLine();
        }
    }

    class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        
        public static bool EmpSearch(Employee emp)
        {
            if (emp.FirstName == "Naresh")
                return true;
            else
                return false;
        }
    }

}
