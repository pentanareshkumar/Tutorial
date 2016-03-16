using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovarianceAndContravariance
{
    class Program
    {
        static void Main(string[] args)
        {
            /*I have created list of stirng and added a new value "Three", Its Perfectly working.*/
            var strings = new List<string>{"One","Two"};
            strings.Add("Three");

            /*I will write the above code using IList, because List must have implemented the IList interface */
            var iliststrings = (IList<string>) strings;
            iliststrings.Add("Four");
            
            /* I cant cast list of String to IList<object>, I will get runtime exception..
             If it would allowed, i would have add different type of vlaues...*/
            var objectList = (IList<Object>)strings;
            objectList.Add(42);

            /* Possible in C#-4.0 - COVARIANCE - There is an important diffence between IList<T> and IEnumerable<T> is
             IEnumerable, IEnumerator never receive value of T, they return value of T */
            var objectSequence = (IEnumerable<Object>)strings;

            /* CONTRAVARIANCE 
            IComparer,IComparable never return value of T, they receive value of T */
            IComparer<string> comparer;


            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

        }
    }
}
