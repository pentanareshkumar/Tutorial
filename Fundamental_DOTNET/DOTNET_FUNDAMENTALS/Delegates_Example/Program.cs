using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Example
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Single Cast Delegates
            clsMaths objMaths = new clsMaths();

            PointertoFunction AddPtr = null;
        
            AddPtr = objMaths.Add;

            int resultAdd = AddPtr.Invoke(1, 2);

            Console.WriteLine("Result Add - {0}", resultAdd);

            PointertoFunction SubPtr = null;

            SubPtr = objMaths.Sub;

            int resultSub = SubPtr.Invoke(2, 1);

            Console.WriteLine("Result Sub - {0}", resultSub);

            //Multicast Delegates
            MultiDelegate MultiPtr = null;
            MultiPtr += objMaths.Addition;
            MultiPtr += objMaths.Substraction;
            MultiPtr.Invoke(3, 1);
            
            Console.ReadLine();

        }
    }
}
