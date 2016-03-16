using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_Example
{
    /*
     * Polymorphism 
        *   Method Overloading
        *   Method Overriding
     * Virtual and Override keyword are used for method overriding and new keyword is used for method hiding. 
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1
            A a = new A();
            a.Test();

            B b = new B();
            b.Test();

            C c = new C();
            c.Test();
            /* output
                A::Test()
                A::Test()
                A::Test()
             */

            //Step 2
            X x = new X();
            Y y = new Y();
            Z z = new Z();

            x.Test();
            y.Test();
            z.Test();
            /* output
                X::Test()
                Y::Test()
                Z::Test()
             */

            /*
            *   virtual: indicates that a function may be overriden by an inheritor

            *   override: overrides the functionality of a virtual function in a base class, providing different functionality.

            *   new/Shadowing: hides the original function (which doesn't have to be virtual), providing different functionality. 
                This should only be used where it is absolutely necessary.
                When you hide a method, you can still access the original method by up casting to the base class. 
                This is useful in some scenarios, but dangerous.
             */
            /* Method Hiding (new keyword) 
             *  For hiding the base class method from derived class simply declare the derived class method with new keyword.
             */
            x = new Y();
            x.Test();
            y = new Z();
            y.Test();
            /* output
                X::Test()
                Y::Test()
             */

            /*
             * When you will run the above program, it will run successfully and gives the O/P. But this program will show the two warnings as shown below:
                    'Polymorphism.B.Test()' hides inherited member 'Polymorphism.A.Test()'. Use the new keyword if hiding was intended.
                    'Polymorphism.C.Test()' hides inherited member 'Polymorphism.B.Test()'. Use the new keyword if hiding was intended.
             */


            //Step 3
            M m = new M();
            N n = new N();
            O o = new O();

            m.Test();
            n.Test();
            o.Test();
            /*  Output
                M::Test()
                N::Test()
                O::Test()
             */

            /* Method Overriding (virtual and override keyword)
             *  In C#, for overriding the base class method in derived class, you have to declare base class method as virtual 
                and derived class method as override as shown below:
             */
            m = new N();
            m.Test();

            n = new O();
            n.Test();
            /*  Output
                N::Test()
                O::Test()
             */

            //Step 4
            /*  Mixing Method Overriding and Method Hiding*/
            // I am overriding Class Q, Test() method in Class R
            P p = new P();
            Q q = new Q();
            R r = new R();

            p.Test();
            q.Test();
            r.Test();
            /*  Output
                P::Test()
                Q::Test()
                R::Test()
             */

            p = new Q();
            p.Test();

            q = new R();
            q.Test();
            /*  Output
                P::Test()
                R::Test()
             */
            Console.ReadKey();

            /*  NOTE - 
             *  The virtual keyword is used to modify a method, property, indexer, or event declared in the base class 
                and allow it to be overridden in the derived class.
             *  The override keyword is used to extend or modify a virtual/abstract method, property, indexer, 
                or event of base class into derived class.
             *  The new keyword is used to hide a method, property, indexer, or event of base class into derived class.
             */
        }
    }

    // Step 1
    class A
    {
        public void Test()
        {
            Console.WriteLine("A::Test()");
        }
    }

    //Step 1

    class B : A
    {

    }

    class C : B
    {

    }

    //Step2 
    class X
    {
        public void Test()
        {
            Console.WriteLine("X::Test()");
        }
    }

    class Y : X
    {
        new public void Test()
        {
            Console.WriteLine("Y::Test()");
        }
    }

    class Z : Y
    {
        public new void Test()
        {
            Console.WriteLine("Z::Test()");
        }
    }

    //Step3
    class M
    {
        public virtual void Test()
        {
            Console.WriteLine("M::Test()");
        }
    }

    class N : M
    {
        public override void Test()
        {
            Console.WriteLine("N::Test()");
        }
    }

    class O : N
    {
        public override void Test()
        {
            Console.WriteLine("O::Test()");
        }
    }

    //Step 4
    class P
    {
        public void Test()
        {
            Console.WriteLine("P::Test()");
        }
    }

    class Q:P
    {
        public new virtual void Test()
        {
            Console.WriteLine("Q::Test()");
        }
    }

    class R : Q 
    {
        public override void Test()
        {
            Console.WriteLine("R::Test()");
        }
    }
}
