using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarKeyword
{
    class Program
    {
        class clsSomeBigClassToDoSomething<T>
        {
            public string CustomerCode{get;set;}
        }

        static void Main(string[] args)
        {
            //Explicit or Direct way of diclaration
            int i = 111;
            
            // Implicit or Indirect way of diclaration
            // Var Keyword looks the right hand side datatype and accordingly creates the create the datatype.
            // Var keyword define data type statically not dynamically.
            var j = 111;

            //lets create an instance of the above class
            clsSomeBigClassToDoSomething<string> obj1 = new clsSomeBigClassToDoSomething<string>();

            //lets create an instance of the above class
            // now the code has become sweet and sort
            //“Var” keyword not only shorten the code but also make the “obj” object strongly type.
            var obj = new clsSomeBigClassToDoSomething<string>();

            //When you are using LINQ and anonymous types “Var” keyword reduces your code for creating special classes.
            //use of var keyword with LINQ and Anonymous type.
            //creating array 
            string[] Arr = { "Feroz", "Kalim", "Shaam", "Moosa" };
            //return values which are greater than length 5.
            //IEnumerable<MyData> obj = from x in Arr
            //                          where x.Length >
            //                              5
            //                          select new MyData { Len = x.Length, Value = x };

            var filterItems = from x in Arr where x.Length > 5 select new { Len = x.Length, Value = x };
        }

    }
}
