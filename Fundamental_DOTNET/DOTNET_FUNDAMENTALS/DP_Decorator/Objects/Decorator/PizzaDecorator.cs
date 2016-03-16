using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Decorator
{
    public class PizzaDecorator : Pizza
    {
        protected Pizza _pizza;
        public PizzaDecorator(Pizza pizza)
        {
            _pizza = pizza;
        }
        public override string GetDescription()
        {
           return _pizza.Description;
        }

        public override double CalculateCost()
        {
            return _pizza.CalculateCost();
        }
    }
}
