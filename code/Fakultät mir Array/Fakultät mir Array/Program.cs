﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakultät_mir_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Fakultät von n: ");
            long n = long.Parse(Console.ReadLine());
            int resultcounter = 0;

            long result = 1;
            long[] results = new long [n+1];
            for (int i = 1; i <= n; i++)
            {
                result *= i;
                

                 results[resultcounter]= result;
                ++resultcounter;


            }
            
            foreach (int k in results)
            {
                Console.WriteLine(k);
            }

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
