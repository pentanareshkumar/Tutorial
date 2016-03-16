using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable_IEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> myList = new List<int>(); ;
            myList.Add(1990);
            myList.Add(1991);
            myList.Add(1992);
            myList.Add(1993);
            myList.Add(1994);
            myList.Add(1995);
            myList.Add(1996);
            myList.Add(1997);
            myList.Add(1998);
            myList.Add(1999);
            myList.Add(2000);
            myList.Add(2001);
            myList.Add(2002);
            myList.Add(2003);
            myList.Add(2004);

            //IEnumerable<int> myEnumerable = (IEnumerable<int>)myList;
            //foreach (var item in myEnumerable)
            //{
            //    Console.WriteLine(item);
            //}

            //IEnumerator<int> myEnumerator = myList.GetEnumerator();
            //while (myEnumerator.MoveNext())
            //{
            //    Console.WriteLine(myEnumerator.Current);
            //}

            //3.	Whenever we pass IEnumerator to another function ,it knows the current position of item/object.
            Traverse1990To1999_IEnumerator(myList.GetEnumerator());
            
            //4.	Whenever we pass IEnumerable collection to another function ,it doesn't know the current position of item/object(doesn't know where I am)
            //Traverse1990To1999_IEnumerable((IEnumerable<int>)myList);

            Console.ReadLine();
        }

        static void Traverse1990To1999_IEnumerator(IEnumerator<int> collection)
        {
            while (collection.MoveNext())
            {
                Console.WriteLine(collection.Current);
                if (Convert.ToInt32(collection.Current) > 1999)
                {
                    Traverse2000To2004_IEnumerator(collection);
                }
            }
        }

        static void Traverse2000To2004_IEnumerator(IEnumerator<int> collection)
        {
            while (collection.MoveNext())
            {
                Console.WriteLine(collection.Current);
            }
        }

        static void Traverse1990To1999_IEnumerable(IEnumerable<int> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
                if (Convert.ToInt32(item) > 1999)
                {
                    Traverse2000To2004_IEnumerable(collection);
                }
            }
        }

        static void Traverse2000To2004_IEnumerable(IEnumerable<int> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}

/*
    1.	IEnumerable uses IEnumerator internally.
    2.	IEnumerable doesn’t know which item/object is executing.
    3.	Whenever we pass IEnumerator to another function ,it knows the current position of item/object.
    4.	Whenever we pass IEnumerable collection to another function ,it doesn't know the current position of item/object(doesn't know where I am)
    5.	IEnumerable have one method GetEnumerator()
 */
