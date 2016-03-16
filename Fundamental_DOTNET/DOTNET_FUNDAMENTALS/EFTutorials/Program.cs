using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTutorials
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolDBEntities())
            {
                var studentList = context.Students.ToList<Student>();

                //Perform create operation
                //context.Students.Add(new Student() { StudentName = "New Student" });

                //Perform Update operation
                //Student studentToUpdate = studentList.Where(s => s.StudentName == "New Student").FirstOrDefault<Student>();
                //studentToUpdate.StudentName = "Edited student1";

                ////Perform delete operation
                context.Students.Remove(studentList.ElementAt<Student>(0));

                //Execute Inser, Update & Delete queries in the database
                context.SaveChanges();

            }
        }
    }
}
