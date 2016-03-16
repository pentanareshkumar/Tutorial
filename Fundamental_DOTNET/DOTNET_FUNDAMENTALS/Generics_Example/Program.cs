using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Check<int> obj = new Check<int>();
            var result = obj.Compare(1, 1);

            Console.ReadLine();
        }
    }
}
