using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class15
    {
        static void Main()
        {
            Random random = new Random();

            int maxNumber = 100;
            int minNumber = 1;

            int number = random.Next(minNumber, maxNumber);

            int result = 1;
            while (number >= result)
                result *= 2;
            Console.WriteLine($"Число {number} в степени двойки {result}");
        }
    }
}