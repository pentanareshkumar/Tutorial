using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTutorial_CF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                //Student student = new Student { StudentName = "Bhavika" };
                //context.Students.Add(student);
                //context.SaveChanges();
            }
        }
    }
}
