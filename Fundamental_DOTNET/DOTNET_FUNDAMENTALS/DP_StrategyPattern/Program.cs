using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_StrategyPattern
{
    /*
     * Let’s understand the widely accepted definition of strategy pattern which you can find from various resources on net. 
        “Strategy pattern defines a family of algorithms, encapsulates each one of them and makes them interchangeable.” 

        1) Family of Algorithms- The definition says that the pattern defines the family of algorithms- 
            it means we have functionality (in these algorithms) which will do the same common thing for our object, but in different ways.

        2) Encapsulate each one of them- The pattern would force you to place your algorithms in different classes (encapsulate them). 
            Doing so would help us in selecting the appropriate algorithm for our object.

        3) Make them interchangeable- The beauty with strategy pattern is we can select at run time which algorithm we should apply to our object 
            and can replace them with one another
     */
    /*
     * Think of applying this pattern for a discounting system, which calculates a discount for different customers. 
        So this system would decide at run time which discounting method to call based on type of customer.
     */
    /*
     * The classes and objects participating in this pattern are:

    * Strategy  (SortStrategy)
        declares an interface common to all supported algorithms. Context uses this interface to call the algorithm defined by a ConcreteStrategy
    * ConcreteStrategy  (QuickSort, ShellSort, MergeSort)
        implements the algorithm using the Strategy interface
    * Context  (SortedList)
        is configured with a ConcreteStrategy object
        maintains a reference to a Strategy object
        may define an interface that lets Strategy access its data.
     */
    class Program
    {
        static void Main(string[] args)
        {
            SortedList StudentRecords = new SortedList();

            StudentRecords.Add("Naresh");
            StudentRecords.Add("Sateesh");
            StudentRecords.Add("Suman");
            StudentRecords.Add("Satya");
            StudentRecords.Add("Jhon");
            StudentRecords.Add("Manjunadh");
            StudentRecords.Add("Anil");

            StudentRecords.SetSortingStrategy(new QuickSort());
            StudentRecords.Sort();

            StudentRecords.SetSortingStrategy(new ShellSort());
            StudentRecords.Sort();

            StudentRecords.SetSortingStrategy(new MergeSort());
            StudentRecords.Sort();

            Console.ReadKey();
        }
    }

    abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }

    class QuickSort: SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort(); //Default is Quick Sort
            Console.WriteLine("QuickSorted List");
        }
    }

    class ShellSort:SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort(); // Acutally have to implement Shell Sort.
            Console.WriteLine("ShellSorted List");
        }
    }

    class MergeSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort(); // Acutally have to implement Merge Sort.
            Console.WriteLine("MergeSorted List");
        }
    }

    class SortedList
    {
        private List<string> _list = new List<string>();
        private SortStrategy _sortStartergy;

        public void SetSortingStrategy(SortStrategy sortStrategy)
        {
            this._sortStartergy = sortStrategy;
        }

        public void Add(string item)
        {
            this._list.Add(item);
        }

        public void Sort()
        {
            _sortStartergy.Sort(_list);

            //Display the items after sorted.
            foreach (var item in _list)
            {
                Console.WriteLine(" " + item);
            }
            Console.WriteLine();
        }
    }

}
