using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consturctor_Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            mySampleClass obj = new mySampleClass();

            //  Constructor Overloading
            mySampleClass obj1 = new mySampleClass(12);

            //Calling Constructor from another Constructor

            //  Behavior of Constructors in Inheritance
            /* Then the sequence of execution will be:
                public myBaseClass() method.
                and then public myDerivedClass() method.
             * Note: If we do not provide initializer referring to the base class constructor then it executes the no parameter constructor of the base class.
             */
            myDerivedClass obj2 = new myDerivedClass();

            /*
             * Then the sequence of execution will be:
                public myBaseClass(int Age) method
                and then public myDerivedClass(int Age) method
             */
            myDerivedClass obj3 = new myDerivedClass(15);


            //  Private Constructors
            /*
             *  Private constructors, the constructors with the "private" access modifier, are a bit special case. 
             *  It is because we can neither create the object of the class, nor can we inherit the class with only private constructors. 
             *  But yes, we can have the set of public constructors along with the private constructors in the class and 
             *  the public constructors can access the private constructors from within the class through constructor chaining.
             */
            MyClass obj4 = new MyClass(10);

            //Static Constructors
            /*
             * This is a special constructor and gets called before the first object is created of the class.
             * The time of execution cannot be determined, but it is definitely before the first object creation.
             * NOTE
                 * There can be only one static constructor in the class.
                 *  The static constructor should be without parameters.
                 *  It can only access the static members of the class.
                 *  There should be no access modifier in static constructor definition.
             */

        }
    }

    public class mySampleClass
    {
        public mySampleClass()
        {
            // This is the constructor method.
        }
        public mySampleClass(int Age)
        {
            // This is the constructor with one parameter.
            // Second Constructor

        }

        public mySampleClass(int Age, string Name)
        {
            // This is the constructor with two parameters.
            // Third Constructor
        }

        // rest of the class members goes here.
    }

    public class myBaseClass
    {
        public myBaseClass()
        {
            // Code for First Base class Constructor
        }

        public myBaseClass(int Age)
        {
            // Code for Second Base class Constructor
        }

        // Other class members goes here
    }

    public class myDerivedClass : myBaseClass
    // Note that I am inheriting the class here.
    {
        public myDerivedClass()
        {
            // Code for the First myDerivedClass Constructor.
        }

        public myDerivedClass(int Age)
            : base(Age)
        {
            // Code for the Second myDerivedClass Constructor.
        }

        // Other class members goes here
    }

    public class MyClass
    {
        private MyClass()
        {
            Console.WriteLine("This is no parameter Constructor");
        }

        public MyClass(int var)
            : this()
        {
            Console.WriteLine("This is one parameter Constructor");
        }
        // Other class methods goes here
    }
    public class myClass
    {
        static myClass()
        {
            // Initialization code goes here.
            // Can only access static members here.
        }
        // Other class methods goes here
    }
}
