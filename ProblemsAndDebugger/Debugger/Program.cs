using System;
using System.Collections.Generic;

namespace Debugger
{
    class Program
    {
        // correct answer up to 100
        static readonly List<int> primeSolution = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

        static void Main(string[] args)
        {
            DoPrimes();
        }

        // Hitta och fixa buggen!
        private static void DoPrimes()
        {
            int limit = 100;
            // we already know that 2 and 3 are primes
            var primeNumbers = new List<int> { 2, 3 };

            for (int counter = 5; counter < limit; counter += 2)
            {
                primeNumbers.Add(counter);
                for (int divider = 3; divider < counter; divider++)
                {
                    if (counter % divider == 0)
                    {
                        break;
                    }
                }
            }

            // checks against the correct solution
            for (int i = 0; i < primeNumbers.Count; i++)
            {
                if(primeSolution.Contains(primeNumbers[i]))
                {
                    Console.WriteLine(primeNumbers[i]);
                }
                else
                {
                    Console.WriteLine("Incorrect");
                }
            }

        }
    }
}
