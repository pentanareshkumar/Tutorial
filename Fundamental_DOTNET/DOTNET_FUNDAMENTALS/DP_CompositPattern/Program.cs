using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_CompositPattern
{
    /*
     *  Hierarchical representations of objects are required.
     *  A single object and a group of objects should be treated in the same way.
     *  The Composite pattern is used when data is organized in a tree structure (for example directories in a computer).
     */
    /// <summary>
    /// The 'Component' Treenode
    /// </summary>
    public interface IEmployeed
    {
        int EmpID { get; set; }
        string Name { get; set; }
    }

    /// <summary>
    /// The 'Composite' class
    /// </summary>
    public class Employee : IEmployeed, IEnumerable<IEmployeed>
    {
        private List<IEmployeed> _subordinates = new List<IEmployeed>();

        public int EmpID { get; set; }
        public string Name { get; set; }

        public void AddSubordinate(IEmployeed emp)
        {
            _subordinates.Add(emp);
        }

        public void RemoveSubordinate(IEmployeed emp)
        {
            _subordinates.Remove(emp);
        }

        public IEmployeed GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public IEnumerator<IEmployeed> GetEnumerator()
        {
            foreach (IEmployeed subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    /// <summary>
    /// The 'Leaf' class
    /// </summary>
    public class Contractor : IEmployeed
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Employee Rahul = new Employee { EmpID = 1, Name = "Rahul" };
            Employee Amit = new Employee { EmpID = 2, Name = "Amit" };
            Employee Mohan = new Employee { EmpID = 3, Name = "Mohan" };

            Rahul.AddSubordinate(Amit);
            Rahul.AddSubordinate(Mohan);

            Employee Rita = new Employee { EmpID = 4, Name = "Rita" };
            Employee Hari = new Employee { EmpID = 5, Name = "Hari" };

            Amit.AddSubordinate(Rita);
            Amit.AddSubordinate(Hari);

            Employee Kamal = new Employee { EmpID = 6, Name = "Kamal" };
            Employee Raj = new Employee { EmpID = 7, Name = "Raj" };

            Contractor Sam = new Contractor { EmpID = 8, Name = "Sam" };
            Contractor tim = new Contractor { EmpID = 9, Name = "Tim" };

            Mohan.AddSubordinate(Kamal);
            Mohan.AddSubordinate(Raj);
            Mohan.AddSubordinate(Sam);
            Mohan.AddSubordinate(tim);

            Console.WriteLine("EmpID = {0} , Name = {1}", Rahul.EmpID, Rahul.Name);

            foreach (Employee Manager in Rahul)
            {
                Console.WriteLine("EmpID = {0} , Name = {1}", Manager.EmpID, Manager.Name);

                foreach (var employee in Manager)
                {
                    Console.WriteLine(" \t EmpID={0}, Name={1}", employee.EmpID, employee.Name);
                }
            }

            Console.ReadKey();
        }
    }
}
