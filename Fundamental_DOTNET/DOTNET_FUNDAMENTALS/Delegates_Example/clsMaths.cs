using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Example
{
    public delegate int PointertoFunction(int x, int y);
    public delegate void MultiDelegate(int x, int y);

    public class clsMaths
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Sub(int x, int y)
        {
            return x - y;
        }

        public void Addition(int x, int y)
        {
            Console.WriteLine("Result_Addition - {0} ", x + y);
        }

        public void Substraction(int x, int y)
        {
            Console.WriteLine("Result_Substraction - {0} ", x - y);
        }
    }
}
