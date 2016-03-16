using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeferredExecution
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sequence operators form first-class queries that 
            // are not executed until you enumerate over them. 

            int[] numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int i = 0;
            var q =
                from n in numbers
                select ++i;

            // Note, the local variable 'i' is not incremented 
            // until each element is evaluated (as a side-effect): 
            foreach (var v in q)
            {
                Console.WriteLine("v = {0}, i = {1}", v, i);
            }

            Console.ReadKey();
        }
    }
}
