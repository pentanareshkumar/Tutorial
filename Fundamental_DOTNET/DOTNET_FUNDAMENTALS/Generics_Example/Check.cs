using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Example
{
    public class Check<T>
    {
        public bool Compare(T i, T j)
        {
            if (i.Equals(j))
            {
                return true;
            }
            else
                return false;
        }
    }
}
