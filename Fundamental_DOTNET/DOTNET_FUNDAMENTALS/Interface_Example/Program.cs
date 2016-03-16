using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Example
{
    /*
     *  An interface acts as a contract between itself and any class or struct which implements it. 
        It means a class that implement an interface is bound to implement all its members. 
        Interface has only member’s declaration or signature and implicitly every member of an interface is public and abstract.
     *  For example, the most common use of interfaces is, within SOA (Service Oriented Architecture). 
        In SOA (WCF), a service is exposed through interfaces to different clients. 
        Typically, an interface is exposed to a group of clients which needs to use common functionalities.
     *  Features of Interface
            *   An interface doesn't provide inheritance like a class or abstract class 
                but it only declare members which an implementing class need to be implement.
            *   It cannot be instantiated but it can be referenced by the class object which implements it. 
                Also, Interface reference works just like object reference and behave like as object.
            *   It contains only properties, indexers, methods, delegates and events signature.
            *   It cannot contains constants members, constructors, instance variables, destructors, static members or nested interfaces.
            *   Members of an interface cannot have any access modifiers even public.
            *   Implicitly, every member of an interface is public and abstract. 
                Also, you are not allowed to specify the members of an interface public and abstract or virtual.
            *   An interface can be inherited from one or more interfaces.
            *   An interface can extend another interface.
            *   A class or struct can implements more than one interfaces.
            *   A class that implements an interface can mark any method of the interface as virtual and this method can be overridden by derived classes.
            *   Implementing multiple interfaces by a class, sometimes result in a conflict between member signatures. 
                You can resolve such conflicts by explicitly implementing an interface member.
     */

    /* When to use
     *  Need to provide common functionality to unrelated classes.
     *  Need to group objects based on common behaviors.
     *  Need to introduce polymorphic behavior to classes since a class can implements more than one interfaces.
     *  Need to provide more abstract view to a model which is unchangeable.
     *  Need to create loosely coupled components, easily maintainable and pluggable components (like log4net framework for logging) because implementation of an interface is separated from itself.
     */

    /*
     * DIFFERENCE BETWEEN AN ABSTRACT CLASS AND AN INTERFACE:
        *   An Abstract class doesn't provide full abstraction but an interface does provide full abstraction; i.e. both a declaration and a definition is given in an abstract class but not so in an interface.
        *   Using Abstract we can not achieve multiple inheritance but using an Interface we can achieve multiple inheritance.
        *   We can not declare a member field in an Interface.
        *   We can not use any access modifier i.e. public , private , protected , internal etc. because within an interface by default everything is public.
        *   An Interface member cannot be defined using the keyword static, virtual, abstract or sealed.
        *   Abstract classes can add more functionality without destroying the child classes that were using the old version.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Document d = new Document();
            d.Read();
            d.Write();
            d.Compress();
            d.DeCompress();
            /*   It cannot be instantiated but it can be referenced by the class object which implements it. 
                Also, Interface reference works just like object reference and behave like as object. */
            //IStore s = new IStore();
            IStore s = new Document();
            s.Read();
            s.Write();

            ICompress c = new Document();
            c.Compress();
            c.DeCompress();

            Console.ReadLine();
        }
    }

    interface IStore
    {
        void Read();
        void Write();
    }

    interface ICompress
    {
        void Compress();
        void DeCompress();
    }

    public class Document : IStore,ICompress
    {

        public void Read()
        {
            Console.WriteLine("Executing Document's Read Method for IStore");
        }

        public void Write()
        {
            Console.WriteLine("Executing Document's Write Method for IStore");
        }

        public void Compress()
        {
            Console.WriteLine("Executing Document's Compress Method for ICompress");
        }

        public void DeCompress()
        {
            Console.WriteLine("Executing Document's DeCompress Method for ICompress");
        }
    }
}
