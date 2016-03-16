using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_AbstractFactoryPattern
{
    interface IScooter
    {
        string Name();
    }

    interface IBike
    {
        string Name();
    }

    class RegularBike : IBike
    {
        public string Name()
        {
            return "Regular Bike - Name";
        }
    }

    class SportsBike : IBike
    {
        public string Name()
        {
            return "Sports Bike - Name";
        }
    }

    class RegularScooter : IScooter
    {
        public string Name()
        {
            return "Regular Scooter - Name";
        }
    }

    class Scooty : IScooter
    {
        public string Name()
        {
            return "Scooty - Name";
        }
    }

    interface IVehicleFactory
    {
        IBike GetBike(string Bike);
        IScooter GetScooter(string Scooter);
    }

    class HondaFactory : IVehicleFactory
    {
        public IBike GetBike(string Bike)
        {
            switch (Bike)
            {
                case "Regular":
                    return new RegularBike();
                case "Sports":
                    return new SportsBike();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Bike));
            }
        }

        public IScooter GetScooter(string Scooter)
        {
            switch (Scooter)
            {
                case "Regular":
                    return new RegularScooter();
                case "Sports":
                    return new Scooty();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Scooter));
                    
            }
        }
    }

    class HeroFactory: IVehicleFactory
    {
        public IBike GetBike(string Bike)
        {
            switch (Bike)
            {
                case "RegularBike":
                    return new RegularBike();
                case "SportsBike":
                    return new SportsBike();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Bike));
            }
        }

        public IScooter GetScooter(string Scooter)
        {
            switch (Scooter)
            {
                case "RegularScooter":
                    return new RegularScooter();
                case "Scooty":
                    return new Scooty();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Scooter));

            }
        }
    }

    class VehicleClient
    {
        IBike bike;
        IScooter scooter;

        public VehicleClient(IVehicleFactory factory, string type)
        {
            bike = factory.GetBike(type);
            scooter = factory.GetScooter(type);
        }

        public string GetBikeName()
        {
            return bike.Name();
        }

        public string GetScooterName()
        {
            return scooter.Name();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IVehicleFactory honda = new HondaFactory();
            VehicleClient hondaClient = new VehicleClient(honda, "Regular");

            Console.WriteLine("******* Honda **********");
            Console.WriteLine(hondaClient.GetBikeName());
            Console.WriteLine(hondaClient.GetScooterName());

            hondaClient = new VehicleClient(honda, "Sports");
            Console.WriteLine(hondaClient.GetBikeName());
            Console.WriteLine(hondaClient.GetScooterName());

            IVehicleFactory hero = new HondaFactory();
            VehicleClient heroClient = new VehicleClient(hero, "Regular");

            Console.WriteLine("******* Hero **********");
            Console.WriteLine(heroClient.GetBikeName());
            Console.WriteLine(heroClient.GetScooterName());

            heroClient = new VehicleClient(honda, "Sports");
            Console.WriteLine(heroClient.GetBikeName());
            Console.WriteLine(heroClient.GetScooterName());

            Console.ReadKey();
        }
    }
}
