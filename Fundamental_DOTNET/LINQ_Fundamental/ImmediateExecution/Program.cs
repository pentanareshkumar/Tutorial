﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmediateExecution
{
    class Program
    {
        static void Main(string[] args)
        {
            // Methods like ToList() cause the query to be 
            // executed immediately, caching the results. 

            int[] numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int i = 0;
            var q = (from n in numbers
                select ++i)
                .ToList();

            // The local variable i has already been fully 
            // incremented before we iterate the results: 
            foreach (var v in q)
            {
                Console.WriteLine("v = {0}, i = {1}", v, i);
            }

            Console.ReadKey();
        }
    }
}
