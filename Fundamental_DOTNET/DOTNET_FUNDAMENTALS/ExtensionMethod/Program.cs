using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Dot Net Tricks Extension Method Example";

            //calling extension method
            var count = s.WordCount();

            Console.WriteLine(s);

            Console.ReadLine();
        }
    }

    //Defining extension method
    public static class MyExtensions
    {
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { '.', ',', ' ' }).Length;
        }
    }

    /*
     * Extension Methods Chaining
     * Like as instance methods, extension methods also have chaining capability.
    public static class ExtensionClass
    {
    public static string Pluralize (this string s) {...}
    public static string Capitalize (this string s) {...}
    }
    //we can do chainig of above methods like as
    string x = "Products".Pluralize().Capitalize(); 
    */

    /*
     * Ambiguity, resolution and precedence of extension method
        To use an extension method, it should be in same scope of class.
        If two extension methods have the same signature,the more specific method takes precedence.
     
        static class StringExtension
        { // first method
         public static bool IsCapitalized (this string s) {...}
        }
        static class ObjectExtension
        {
         // second method
         public static bool IsCapitalized (this object s) {...}
        }
        // code here
        // first method is called
        bool flag1 = "Dotnet-Tricks".IsCapitalized(); 
        // second method is called
        bool test2 = (ObjectHelper.IsCapitalized ("Dotnet-Tricks")); 
     */
}

/*
   * Key points about extension methods
        1. An extension method is defined as static method but it is called like as instance method.
        2. An extension method first parameter specifies the type of the extended object, and it is preceded by the "this" keyword.
        3. An extension method having the same name and signature like as an instance method will never be called since it has low priority than instance method.
        4. An extension method couldn't override the existing instance methods.
        5. An extension method cannot be used with fields, properties or events.
        6. The compiler doesn't cause an error if two extension methods with same name and signature are defined in two different namespaces and these namespaces are included in same class file using directives. Compiler will cause an error if you will try to call one of them extension method.
 */
