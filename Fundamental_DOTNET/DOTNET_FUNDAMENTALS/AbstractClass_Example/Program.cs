using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass_Example
{
    /*
     *  Abstract class is a special type of class which cannot be instantiated and acts as a base class for other classes. 
        Abstract class members marked as abstract must be implemented by derived classes.
     *  The purpose of an abstract class is to provide basic or default functionality 
        as well as common functionality that multiple derived classes can share and override.
     *  Example - C#, System.IO.FileStream is an implementation of the System.IO.Stream abstract class.
     *  Features of Abstract Class
            *   An abstract class cannot be instantiated.
            *   An abstract class contain abstract members as well as non-abstract members.
            *   An abstract class cannot be a sealed class because the sealed modifier prevents a class from being inherited and the abstract modifier requires a class to be inherited.
            *   A non-abstract class which is derived from an abstract class must include actual implementations of all the abstract members of parent abstract class.
            *   An abstract class can be inherited from a class and one or more interfaces.
            *   An Abstract class can has access modifiers like private, protected, internal with class members. But abstract members cannot have private access modifier.
            *   An Abstract class can has instance variables (like constants and fields).
            *   An abstract class can has constructors and destructor.
            *   An abstract method is implicitly a virtual method.
            *   Abstract properties behave like abstract methods.
            *   An abstract class cannot be inherited by structures.
            *   An abstract class cannot support multiple inheritance.
     */

    /*  When to use Abstract Class
            *   If you want to provide common, implemented functionality among all implementations of your component, use an abstract class. 
                Abstract classes allow you to partially implement your class, whereas interfaces contain no implementation for any members.
     */

    /*
     * DIFFERENCE BETWEEN AN ABSTRACT CLASS AND AN INTERFACE:
        *   An Abstract class doesn't provide full abstraction but an interface does provide full abstraction; i.e. both a declaration and a definition is given in an abstract class but not so in an interface.
        *   Using Abstract we can not achieve multiple inheritance but using an Interface we can achieve multiple inheritance.
        *   We can not declare a member field in an Interface.
        *   We can not use any access modifier i.e. public , private , protected , internal etc. because within an interface by default everything is public.
        *   An Interface member cannot be defined using the keyword static, virtual, abstract or sealed.
     */
    class Program
    {
        static void Main(string[] args)
        {
            //Cannot create the instance of an Abstract Class..
            //Shape shape = new Shape();

            Square s = new Square(4);
            Console.WriteLine("The Area of Square : {0}", s.Area());

            Rectangle r = new Rectangle(4, 5);
            Console.WriteLine("The Area of Rectangle :{0}", r.Area());


            /*BaseEmployee Object can not be created since this is declared as Abstract
            Following LOCs will return compilation error if uncommented.*/

            //BaseEmployee baseEmployee = new BaseEmployee();
            //baseEmployee.EmployeeID = "EMP001";
            //baseEmployee.EmployeeAddress = "3400 Lee Highway, VA 22031";
            //baseEmployee.EmployeeName = "John Doe";

            //Base Employee Calculate Salary can be called that shouldn't be accessible
            //var baseSalary = baseEmployee.CalculateSalary(34);

            //Full Time and Contract Employees objects are successfully created.
            BaseEmployee fullTimeEmployee = new FullTimeEmployee();
            var fteSalary = fullTimeEmployee.CalculateSalary(40);

            BaseEmployee contractEmployee = new ContractEmployee();
            var CteSalary = contractEmployee.CalculateSalary(40);

            Console.ReadLine();
        }
    }

    abstract class Shape
    {
        // An abstract class contain abstract members as well as non-abstract members.
        abstract public int Area();

        public void NameOfShape()
        {

        }

    }

    class Square : Shape
    {
        int side = 0;

        public Square(int n)
        {
            side = n;
        }
        public override int Area()
        {
            return side * side;
        }
    }

    class Rectangle : Shape
    {
        int length = 0;
        int width = 0;

        public Rectangle(int l, int w)
        {
            length = l;
            width = w;
        }
        public override int Area()
        {
            return length * width;
        }
    }

    abstract class BaseEmployee
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeAddress { get; set; }

        public virtual double CalculateSalary(int hoursWorked)
        {
            throw new NotImplementedException();
        }
    }

    class FullTimeEmployee : BaseEmployee
    {
        public override double CalculateSalary(int hoursWorked)
        {
            return hoursWorked * 60.00 + 4000;
        }
    }

    class ContractEmployee : BaseEmployee
    {
        public override double CalculateSalary(int hoursWorked)
        {
            return hoursWorked * 65.00;
        }
    }
}
