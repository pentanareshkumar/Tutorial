using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Flavors
{
    internal class Program
    {
        protected delegate int tempFunctionPointer(string strParameter, int intParamater);

        public static void Main()
        {
            DelegateSample tempObj = new DelegateSample();

            tempFunctionPointer funcPointer = tempObj.FirstTestFunction;
            funcPointer("hello", 1);
            Console.ReadKey();

            funcPointer = tempObj.SecondTestFunction;
            funcPointer.BeginInvoke("Hello", 1, null, null);
            //funcPointer("hello", 2);
            Console.ReadKey();

            /* Func is always used when you have return object or type from method. If you have void method, you should be using Action. */
            Func<string, int, int> tempFuncPointer = tempObj.FirstTestFunction;
            int value = tempFuncPointer("hello", 3);
            Console.ReadKey();

            /* Action is used when we do not have any return type from method. Method with void signature is being used with Action delegate. */
            Action<string, int> tempActionPointer = tempObj.ThirdTestFunction;
            tempActionPointer("hello", 4);
            Console.ReadKey();

            /* Predicate is a function pointer for method which returns boolean value. They are commonly used for iterating a collection or to verify if the value does already exist. */
            Predicate<Employee> tempPredicatePointer = tempObj.FourthTestFunction;
            Employee[] lstEmployee = (new Employee[]
            {
                new Employee(){ Name = "Ashwin", Age = 31},
                new Employee(){ Name = "Akil", Age = 25},
                new Employee(){ Name = "Amit", Age = 28},
                new Employee(){ Name = "Ajay", Age = 29},
            });

            Employee tempEmployee = Array.Find(lstEmployee, tempPredicatePointer);
            Console.WriteLine("Person below 27 age :" + tempEmployee.Name);
            Console.ReadKey();

            /* Convertor delegate is used when you need to migrate / convert one collection into another by using some algorithm. 
             Object A gets converted into Object B. */
            Converter<Employee, XEmployee> tempConvertorPointer
                = new Converter<Employee, XEmployee>(tempObj.FifthTestFunction);
            XEmployee[] xEmployee = Array.ConvertAll(lstEmployee, tempConvertorPointer);
            Console.ReadKey();

            /* Comparison delegate is used to sort or order the data inside a collection.
             It takes two parameters as generic input type and return type should always be int.
             This is how we can declare Comparison delegate. */
            Comparison<Employee> tempComparisonPointer
                = new Comparison<Employee>(tempObj.SixTestFunction);
            Array.Sort(lstEmployee, tempComparisonPointer);
            Console.ReadKey();


        }

    }

    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class XEmployee
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public bool IsExEmployee
        {
            get { return true; }
        }
    }

    public class DelegateSample
    {
        public int FirstTestFunction(string strParameter, int intParamater)
        {
            Console.WriteLine("First Test Function Execution");
            Console.WriteLine(strParameter);
            return intParamater;
        }

        public int SecondTestFunction(string strParameter, int intParamater)
        {
            Console.WriteLine("Second Test Function Execution");
            Console.WriteLine(strParameter);
            return intParamater;
        }

        public void ThirdTestFunction(string strParameter, int intParamater)
        {
            Console.WriteLine("Third Test Function Execution");
            Console.WriteLine(strParameter);
        }

        public bool FourthTestFunction(Employee employee)
        {
            return employee.Age < 27;
        }

        public XEmployee FifthTestFunction(Employee employee)
        {
            return new XEmployee() { Name = employee.Name, Age = employee.Age };
        }

        public int SixTestFunction(Employee strParameter1, Employee strParamater2)
        {
            return strParameter1.Name.CompareTo(strParamater2.Name);
        }

    }
}
