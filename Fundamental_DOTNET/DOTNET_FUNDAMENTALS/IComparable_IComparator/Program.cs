using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Both IComparable  and IComparer interface allows us to do custom sorting in our collection. 
 * The difference is IComparable allows sorting on only one property while IComparer on multiple properties in our class.
 */
namespace IComparable_IComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();
            list.Add(new Employee() { Name = "Steve", Salary = 10000 });
            list.Add(new Employee() { Name = "Janet", Salary = 10000 });
            list.Add(new Employee() { Name = "Andrew", Salary = 10000 });
            list.Add(new Employee() { Name = "Bill", Salary = 500000 });
            list.Add(new Employee() { Name = "Lucy", Salary = 8000 });

            // Uses IComparable.CompareTo()
            //list.Sort();

            Employee_SortBySalaryByAscendingOrder eAsc =  new Employee_SortBySalaryByAscendingOrder();
            // Sort Employees by salary by ascending order.   
            //list.Sort(eAsc);

            Employee_SortBySalaryByDescendingOrder eDsc = new Employee_SortBySalaryByDescendingOrder();
            // Sort Employees by salary by descending order. 
            //list.Sort(eDsc);

            Employee_SortByName eName = new Employee_SortByName();
            // Sort Employees by their names.                                 
            list.Sort(eName);


            //Use Employee.ToString();
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }

        /* IComparable - 
         IComparable allows custom sorting of objects when implemented. 
         When a class implements this interface, we must add the public method CompareTo(T). 
         We implement custom sorting for a class with IComparable.
         
         * In the below code, we are sorting objects based on salary of employee in descending order, 
         by implementing CompareTo() method of IComparable interface which takes Employee reference as a parameter.
        Now, calling empList.Sort() gives no exception and empList is well sorted by salary. 
         */
        public class Employee : IComparable<Employee>
        {
            public int Salary { get; set; }
            public string Name { get; set; }

            public int CompareTo(Employee other)
            {
                //// Alphabetic sort if salary is equal. [A to Z]
                //if (this.Salary == other.Salary)
                //{
                //    return this.Name.CompareTo(other.Name);
                //}

                //// Default to salary sort. [High to low]
                //return other.Salary.CompareTo(this.Salary);

                if (this.Salary < other.Salary) return 1;
                else if (this.Salary > other.Salary) return -1;
                else return 0;
            }

            public override string ToString()
            {
                // String representation.
                return this.Salary.ToString() + "," + this.Name;
            }
        }

        /* 
        1. Sort Employees by Salary in Ascending Order
        2. Sort Employees by Salary in Descending Order
        3. Sort Employees by Name 
        To solve this problem, .NET provides a special interface called IComparer<> which has a method Compare(), 
        takes two object parameters X, Y and returns an int.
        Use of IComparer<> interface tells List how exactly you want to sort
         */
        public class Employee_SortBySalaryByAscendingOrder :IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {
                if (x.Salary > y.Salary) return 1;
                else if (x.Salary < y.Salary) return -1;
                else return 0;
            }
        }

        public class Employee_SortBySalaryByDescendingOrder: IComparer<Employee>
        {

            public int Compare(Employee x, Employee y)
            {
                if (x.Salary < y.Salary) return 1;
                else if (x.Salary > y.Salary) return -1;
                else return 0;
            }
        }

        public class Employee_SortByName : IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {
                return string.Compare(x.Name, y.Name);
            }
        }
    }
}
