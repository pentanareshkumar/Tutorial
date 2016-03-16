using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Adapter
{
    //Adaptee
    public class HRSystem
    {
        public string[][] GetEmployees()
        {
            string[][] employees = new string[4][];

            employees[0] = new string[] { "100", "Deepak", "Team Leader" };
            employees[1] = new string[] { "101", "Rohit", "Developer" };
            employees[2] = new string[] { "102", "Gautam", "Developer" };
            employees[3] = new string[] { "103", "Dev", "Tester" };

            return employees;
        }
    }

    //ITarget interface
    public interface ITarget
    {
        List<Employe> GetEmployeeList();
    }

    public class Employe
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", this.Id, this.Name, this.Designation);
        }
    }

    //Adapter Class
    public class EmployeAdapter : HRSystem, ITarget
    {
        public List<Employe> GetEmployeeList()
        {
            List<Employe> employeeList = new List<Employe>();

            string[][] employees = GetEmployees();

            var resultList = employees.Select(x => new Employe { Id = x[0], Designation = x[2], Name = x[1] });
            var result = (from x in employees
                         select new 
                         {
                             Id = x[0],
                             Designation = x[2],
                             Name = x[1]
                         }).ToList();

            foreach (var employe in employees)
            {
                Employe emp = new Employe{
                                    Id = employe[0],
                                    Name = employe[1],
                                    Designation = employe[2]
                                };
                employeeList.Add(emp);
            }
           
            return employeeList;
        }
    }

    //Client class which is expecting list of employees
    public class BillingSystem
    {
        private ITarget _employeeSource;
        public BillingSystem(ITarget employeeSource)
        {
            _employeeSource = employeeSource;
        }

        public void ShowEmployeeList()
        {
            List<Employe> employee = _employeeSource.GetEmployeeList();

            Console.WriteLine("######### List Of Employee #########");
            foreach (var employe in employee)
            {
                Console.WriteLine(employe.ToString());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ITarget Itarget = new EmployeAdapter();

            BillingSystem client = new BillingSystem(Itarget);
            client.ShowEmployeeList();

            Console.ReadKey();
        }
    }
}
