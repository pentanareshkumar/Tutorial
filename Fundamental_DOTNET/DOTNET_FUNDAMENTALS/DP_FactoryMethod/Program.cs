using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_FactoryMethod
{
    /*
        What is Factory Method Pattern?
        In Factory pattern, we create object without exposing the creation logic. 
        In this pattern, an interface is used for creating an object, but let subclass decide which class to instantiate. 
        The creation of object is done when it is required. The Factory method allows a class later instantiation to subclasses.
     */
    class Program
    {
        /// <summary>
        /// Factory Pattern Demo
        /// </summary>
        static void Main(string[] args)
        {
            VehicleFactory factory = new ConcreteVehicleFactory();

            IFactory scooter = factory.GetVehicle("Scooter");
            scooter.Milage(25);

            IFactory bike = factory.GetVehicle("Bike");
            bike.Milage(45);

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Product' interface
    /// </summary>
    public interface IFactory
    {
        void Milage(int miles);
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class Scooter :IFactory
    {
        public void Milage(int miles)
        {
            Console.WriteLine("Scooter gives {0} miles/hour Milage", miles.ToString());
        }
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class Bike:IFactory
    {
        public void Milage(int miles)
        {
            Console.WriteLine("Bike gives {0} miles/hour Milage", miles.ToString());
        }
    }

    /// <summary>
    /// The Creator Abstract Class
    /// </summary>
    public abstract class VehicleFactory
    {
        public abstract IFactory GetVehicle(string Vehicle);
    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    public class ConcreteVehicleFactory : VehicleFactory
    {
        public override IFactory GetVehicle(string Vehicle)
        {
            switch (Vehicle)
            {
                case "Scooter":
                    return new Scooter();
                case "Bike":
                    return new Bike();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Vehicle));
            }
        }
    }
}

/*
 When to use it?
    1. Subclasses figure out what objects should be created.
    2. Parent class allows later instantiation to subclasses means the creation of object is done when it is required.
    3. The process of objects creation is required to centralize within the application.
    4. A class (creator) will not know what classes it will be required to create.
 */