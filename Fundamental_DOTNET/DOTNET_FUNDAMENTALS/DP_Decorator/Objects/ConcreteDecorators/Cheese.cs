using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Decorator
{
    public class Cheese : PizzaDecorator
    {
        public Cheese(Pizza pizza)
            : base(pizza)
        {
            Description = "Cheese";
        }

        public override string GetDescription()
        {
            return string.Format("{0}, {1}", _pizza.GetDescription(), Description);
        }

        public override double CalculateCost()
        {
            return _pizza.CalculateCost() + 1.25;
        }
    }
}
