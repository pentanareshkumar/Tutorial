using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousMethod_Example
{
    delegate int MathOp(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            /*  1.	A variable, declared outside the anonymous method can be accessed inside the anonymous method.
                2.	A variable, declared inside the anonymous method can’t be accessed outside the anonymous method. */

            int z = 3;

            MathOp d1 = delegate(int x, int y) { return x * y * z; };

            int z1 = d1(2, 3);

            Console.WriteLine("Result -  {0}", z1);

            /*Anonymous is prefered over Tuple */

            string FullName = "Naresh Kumar Penta";

            //Tuple
            Tuple<string, string, string> tResult = ParseData(FullName);
            Console.WriteLine("First Name: {0}, Middle Name: {1}, Last Name: {2} ", tResult.Item1, tResult.Item2, tResult.Item3);

            //Anonymous
            var Result = Cast(ParseDataA(FullName), new { FirstName = "", MiddleName = "", LastName = "" });
            Console.WriteLine("First Name: {0}, Middle Name: {1}, Last Name: {2} ", Result.FirstName, Result.MiddleName, Result.LastName);

            Console.ReadLine();
        }

        static Tuple<string, string, string> ParseData(string strData)
        {
            string[] arrayData = new string[3];
            arrayData = strData.Split(' ');

            return Tuple.Create<string, string, string>(arrayData[0], arrayData[1], arrayData[2]);
        }

        static object ParseDataA(string strData)
        {
            string[] arrayData = new string[3];
            arrayData = strData.Split(' ');

            return new
            {
                FirstName = arrayData[0],
                MiddleName = arrayData[1],
                LastName = arrayData[2]
            };
        }

        static T Cast<T>(object obj, T type)
        {
            return (T)obj;
        }


    }
}
