using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Decorator
{
    public class MediumPizza :Pizza
    {
        public MediumPizza()
        {
            Description = "Medium Pizza";
        }
        public override string GetDescription()
        {
            return Description;
        }

        public override double CalculateCost()
        {
            return 6.00;
        }
    }
}
