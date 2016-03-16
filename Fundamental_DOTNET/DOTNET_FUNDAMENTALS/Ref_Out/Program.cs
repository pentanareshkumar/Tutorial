using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ref_Out
{
    class Program
    {
        static void Main(string[] args)
        {
            int val1 = 0; //must be initialized
            int val2; //optional

            Ref_Example(ref val1);
            Console.WriteLine(val1);

            Out_Exmaple(out val2);
            Console.WriteLine(val2);

            Console.ReadLine();

        }
        static void Ref_Example(ref int value) //called method
        {
            value = 1;
        }
        static void Out_Exmaple(out int value) //called method
        {
            value = 2; //must be initialized 
        }

        /*
        1. Do not be confused with the concept of passing by reference and the concept of reference type. These two concepts are not the same.
        2. A value type or a reference type can be passed to method parameter by using ref keyword. There is no boxing of a value type when it is passed by reference.
        3. Properties cannot be passed to ref or out parameters since internally they are functions and not members/variables.
         */
    }

    /*
     Both ref and out cannot be used in method overloading simultaneously. 
     However, ref and out are treated differently at run-time but they are treated same at compile time 
     (CLR doesn't differentiates between the two while it created IL for ref and out). 
     Hence methods cannot be overloaded when one method takes a ref parameter and other method takes an out parameter.
    
    class MyClass
    {
        public void Method(out int a) // compiler error “cannot define overloaded”
        {
            // method that differ only on ref and out"
        }
        public void Method(ref int a)
        {
            // method that differ only on ref and out" 
        }
    }
    */

    class MyClass
    {
        public void Method(int a)
        {

        }
        public void Method(out int a)
        {
            a = 2;
            // method differ in signature.
        }
    }
}
