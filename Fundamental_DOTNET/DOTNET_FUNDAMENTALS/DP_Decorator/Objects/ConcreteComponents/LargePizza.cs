using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Decorator
{
    public class LargePizza :Pizza
    {
        public LargePizza()
        {
            Description = "Large Pizza";
        }
        public override string GetDescription()
        {
            return Description;
        }

        public override double CalculateCost()
        {
            return 9.00;
        }
    }
}
