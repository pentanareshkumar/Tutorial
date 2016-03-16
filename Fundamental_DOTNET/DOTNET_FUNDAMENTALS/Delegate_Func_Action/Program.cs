using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Func_Action
{
   /* 
    * The Func and Action generic delegates were introduced in the .NET Framework version 3.5.

    * Whenever we want to use delegates in our examples or applications, typically we use the following procedure:

        Define a custom delegate that matches the format of the method.
        Create an instance of a delegate and point it to a method.
        Invoke the method.
        But, using these 2 Generics delegates we can simply eliminate the above procedure.
        Since both the delegates are generic, you will need to specify the underlaying types of each parameters as well while pointing it to a function. 
        For for example Action<type,type,type……>

        Action<>
        The Generic Action<> delegate is defined in the System namespace of microlib.dll
        This Action<> generic delegate, points to a method that takes up to 16 Parameters and returns void.

        Func<>
        The generic Func<> delegate is used when we want to point to a method that returns a value.
        This delegate can point to a method that takes up to 16 Parameters and returns a value.
        Always remember that the final parameter of Func<> is always the return value of the method. 
        (For examle Func< int, int, string>, this version of the Func<> delegate will take 2 int parameters and returns a string value.)
    */
    class Program
    {
        static void Main(string[] args)
        {
            Action printText = new Action(MethodCollections.PrintText);
            Action<int, int> printNumbers = new Action<int, int>(MethodCollections.PrintNumbers);
            Action<string> print = new Action<string>(MethodCollections.Print);

            Console.WriteLine("\n************************ Action<> Delegate Methods *************************\n");
            printText();
            printNumbers(2, 10);
            print("Naresh Kumar");

            Func<int, int, int> addition = new Func<int, int, int>(MethodCollections.Addition);
            Func<int, int, string> displayAddition = new Func<int, int, string>(MethodCollections.DisplayAddition);
            Func<string, string, string> showCompleteName = new Func<string, string, string>(MethodCollections.SHowCompleteName);
            Func<int> showNumber = new Func<int>(MethodCollections.ShowNumber);

            Console.WriteLine("\n************************ Func<> Delegate Methods *************************\n");
            var rAddition = addition(3, 5);
            Console.WriteLine(rAddition.ToString());

            var rdisplayAddition = displayAddition(3, 5);
            Console.WriteLine(rdisplayAddition);

            var rshowCompleteName = showCompleteName("Naresh", "Kumar");
            Console.WriteLine(rshowCompleteName);

            var rshowNumber = showNumber();
            Console.WriteLine(rshowNumber);

            Console.ReadLine();

        }
    }

    class MethodCollections
    {
        //Methods that takes parameters but returns nothing:
        public static void PrintText()
        {
            Console.WriteLine("Text Printed with the help of Action"); 
        }
        public static void PrintNumbers(int start, int target)
        {
            for (int i = start; i <= target; i++)
            {
                Console.Write(" {0}", i);
            }
            Console.WriteLine();
        }
        public static void Print(string message)
        {
            Console.WriteLine(message);
        }

        //Methods that takes parameters and returns a value:
        public static int Addition(int a, int b)
        {
            return a + b;
        }
        public static string DisplayAddition(int a, int b)
        {
            return string.Format("Addition of {0} and {1} is {2}", a, b, a + b);
        }
        public static string SHowCompleteName(string firstName, string lastName)
        {
            return string.Format("Your Name is {0} {1}", firstName, lastName);
        }
        public static int ShowNumber()
        {
            Random r = new Random();
            return r.Next();
        }       
    }
}
