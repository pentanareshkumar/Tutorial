using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Decorator
{
    /*
     * The Decorator allows you to modify an object dynamically
     * You would use it when you want the capabilities of iheritance with subclasses, but you need to add functionality at run time.
     * It is more flexible than inheritance.
     * Simplifies code because you add functionality using many simple classes.
     * Rather than rewrite old code you can extend with new code
     */

    class Program
    {
        static void Main(string[] args)
        {
            HondaCity car = new HondaCity();

            Console.WriteLine("{0} car {1} model base price is {0}", car.Make, car.Model, car.Price);

            DiwaliSpecialOffer offer = new DiwaliSpecialOffer(car);
            offer.DiscountPercentage = 10;
            offer.Offer = "10 % Discount";

            Console.WriteLine("{0} @ Diwali Special Offer and price are {1}.", offer.Offer, offer.Price);

            Pizza largePizza = new LargePizza();
            largePizza = new Cheese(largePizza);
            largePizza = new Ham(largePizza);
            largePizza = new Peppers(largePizza);

            Console.WriteLine(largePizza.GetDescription());
            Console.WriteLine("{0:C2}",largePizza.CalculateCost());

            Console.ReadKey();
        }
    }

    public interface IVehicle
    {
        string Make { get; }
        string Model { get; }
        double Price { get; }
    }

    class HondaCity : IVehicle
    {

        public string Make
        {
            get { return "Honda City"; }
        }

        public string Model
        {
            get { return "CNG"; }
        }

        public double Price
        {
            get { return 1000000; }
        }
    }

    public abstract class VehicleDecorator : IVehicle
    {
        private IVehicle _vehicle;

        public VehicleDecorator(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public string Make
        {
            get { return _vehicle.Make; }
        }

        public string Model
        {
            get { return _vehicle.Model; }
        }

        public double Price
        {
            get { return _vehicle.Price; }
        }
    }

    public class DiwaliSpecialOffer : VehicleDecorator
    {
        public DiwaliSpecialOffer(IVehicle vehicle)
            : base(vehicle)
        {

        }
        public int DiscountPercentage { get; set; }
        public string Offer { get; set; }

        public double Price
        {
            get
            {
                double price = base.Price;
                int percentage = 100 - DiscountPercentage;
                return Math.Round((price * percentage) / 100, 2);
            }
        }
    }
   
}
