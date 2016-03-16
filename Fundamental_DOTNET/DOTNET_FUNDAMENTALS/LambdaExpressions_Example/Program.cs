using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressions_Example
{
    class Program
    {
        delegate double CalAreaPointer(int r);
        /* Normal Instanciate the Delegate*/
        //static CalAreaPointer cpointer = CalculateArea;

        static void Main(string[] args)
        {
            /* Anonymous Method Style ... */
            //CalAreaPointer cpointer = delegate(int r) { return 3.14 * r * r; }; 

            /*Lambda Expression ..*/
            //CalAreaPointer cpointer = r => 3.14 * r * r;

            /* Func<>*/
            Func<int, Double> cpointer = r => 3.14 * r * r;

            Console.WriteLine("Area of the Circle : {0}", cpointer.Invoke(3));
            Console.ReadLine();
        }

        static double CalculateArea(int r)
        {
            return 3.14 * r * r;
        }
    }
}
