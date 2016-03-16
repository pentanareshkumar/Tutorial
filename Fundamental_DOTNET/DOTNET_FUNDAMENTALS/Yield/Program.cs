using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield
{
    class Program
    {
        static void Main(string[] args)
        {
            FillVaules();
            //Custom Iteration
            //foreach (var item in FilterValues())
            //Satefull Iteration
            foreach (var item in RunningTotal())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        static List<int> mylist = new List<int>();
        static void FillVaules()
        {
            mylist.Add(1);
            mylist.Add(2);
            mylist.Add(3);
            mylist.Add(4);
            mylist.Add(5);
            mylist.Add(6);
            mylist.Add(7);
        }

        static IEnumerable<int> FilterValues()
        {
            //List<int> tempList = new List<int>();
            foreach (var item in mylist)
            {
                if (item > 3)
                {
                    //tempList.Add(item);
                    yield return item;
                }
            }

            //return tempList;
        }

        //Stateful Iteration
        static IEnumerable<int> RunningTotal()
        {
            int runningTotal = 0;
            foreach (var item in mylist)
            {
                runningTotal += item;
                yield return runningTotal;
            }
        }
    }
}
