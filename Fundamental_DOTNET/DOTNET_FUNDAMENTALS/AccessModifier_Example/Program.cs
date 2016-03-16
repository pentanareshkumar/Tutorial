using AccessModifiersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    ACCESS MODIFIERS
    * The default access modifier is private for class members.
    * The one thumb rule is that members of a class can freely access each other.
    * So , since method AAA is private, therefore no one else can have access to it except Modifiers class.
    * We cannot access the method AAA even after we introduced a new modifier named protected. But BBB can access AAA method because it lies in the same class.
    *  Whenever we mark a method with the specifier, protected, we are actually telling C# that only derived classes can access that method and no one else can.
    
 * *    Private means only the same class has access to the members, 
        Public means everybody has access and 
        Protected lies in between where only derived classes have access to the base class method.
 
    * Internal modifier means that access is limited to current program only. 
      So try never to create a component and mark the class internal as no one would be able to use it.
      We should not forget that by default if no modifier is specified, the class is internal.
 
    * Point to remember: Namespaces as we see by default can have no accessibility specifiers at all. 
      They are by default public and we cannot add any other access modifier including public again too.
 
    * Point to remember: A class can only be public or internal. 
    It cannot be marked as protected or private. The default is internal for the class.
 
    * Point to remember: Members of a class can be marked with all the access modifiers, 
    and the default access modifier is private.
 
    * An internal marked member means that no one from outside that DLL can access the member.
    * Protected internal modifier indicates two things, 
        that either the derived class or the class in the same file can have access to that method, 
        therefore in the above mentioned scenario, the derived class ClassB and the classA in the same file, 
        i.e., ClassC can access that method of ClassA marked as protected internal.
        Point to remember: Protected internal means that the derived class and the class within 
        the same source code file can have access.
    
    * Point to remember: In between public and internal, public always allows greater access to its members.
    * Point to remember: The base class always allows more accessibility than the derived class.
    * Point to remember: The return values of a method must have greater accessibility than that of the method itself.
    
    * Only one access modifier is allowed for a member or type, except when you use the protected internal combination
 
    SEALED CLASS
    * Point to remember: Since we cannot derive from sealed classes, the code from the sealed classes cannot be overridden
 
    CONSTANTS
    * Point to remember: We need to initialize the const variable at the time we create it. We are not allowed to initialize it later in our code or program.
    * A constant by default is static and we can’t use the instance reference, i.e., a name to reference a const. 
      A const has to be static as no one will be allowed to make any changes to a const variable.
   
    STATIC VARIABLES
    * Point to remember: Static variables are always initialized when the class is loaded first. 
    An int is given a default value of zero and a bool is given a default to False.
    
 */
namespace AccessModifier_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Modifiers.BBB();
            //Modifiers.AAA();
            //Modifiers1.AAA();

            // Internal Modifier at Class Level
            // ClassA classA;

            ClassC classC = new ClassC();
            classC.MethodClassC();

            Console.ReadLine();
        }
    }

    class Modifiers
    {
        static void AAA()
        {
            Console.WriteLine("Modifiers AAA");
        }

        public static void BBB()
        {
            Console.WriteLine("Modifiers BBB");
            AAA();
        }
    }

    class Modifiers1
    {
        protected static void AAA()
        {
            Console.WriteLine("Modifiers AAA");
        }

        public static void BBB()
        {
            Console.WriteLine("Modifiers BBB");
            AAA();
        }
    }

    class ModifiersBase
    {
        static void AAA()
        {
            Console.WriteLine("ModifiersBase AAA");
        }
        public static void BBB()
        {
            Console.WriteLine("ModifiersBase BBB");
        }
        protected static void CCC()
        {
            Console.WriteLine("ModifiersBase CCC");
        }
    }

    class ModifiersDerived : ModifiersBase
    {
        public static void XXX()
        {
            //AAA();
            BBB();
            CCC();
        }
    }

    /* Point to remember: In between public and internal, public always allows greater access to its members.
    * Point to remember: The base class always allows more accessibility than the derived class.
    class AAA
    {

    }
    public class BBB : AAA
    {

    } */

    /* Point to remember: The return values of a method must have greater accessibility than that of the method itself.
     class AAA
     {

     }
     public class BBB
     {
         public AAA MethodB()
         {
             AAA aaa = new AAA();
             return aaa;
         }
     }*/
}


/* 
    Summary
    Let’s recall all the points that we have to remember:

    1. The default access modifier is private for class members.
    2. A class marked as internal can have its access limited to the current assembly only.
    3. Namespaces as we see by default can have no accessibility specifiers at all. They are by default public and we cannot add any other access modifier including public again too.
    4. A class can only be public or internal. It cannot be marked as protected or private. The default is internal for the class.
    5. Members of a class can be marked with all the access modifiers, and the default access modifier is private.
    6. Protected internal means that the derived class and the class within the same source code file can have access.
    7. Between public and internal, public always allows greater access to its members.
    8. Base class always allows more accessibility than the derived class.
    9. The return values of a method must have greater accessibility than that of the method itself.
    10.A class marked sealed can’t act as a base class to any other class.
    11.Since we cannot derive from sealed classes, the code from the sealed classes cannot be overridden.
    12.We need to initialize the const variable at the time we create it. We are not allowed to initialize it later in our code or program.
    13.Like classes, const variables cannot be circular, i.e., they cannot depend on each other.
    14.A const field of a reference type other than string can only be initialized with null.
    15.One can only initialize a const variable to a compile time value, i.e., a value available to the compiler while it is executing.
    16. A constant by default is static and we can’t use the instance reference, i.e., a name to reference a const. A const has to be static as no one will be allowed to make any changes to a const variable.
    17.A const variable cannot be marked as static.
    18.A variable in C# can never have an uninitialized value.
    19.Static variables are always initialized when the class is loaded first. An int is given a default value of zero and a bool is given a default of False.
    20.An instance variable is always initialized at the time of creation of its instance.
    21.A static readonly field cannot be assigned to (except in a static constructor or a variable initializer).
 */