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
            int result = 1;
            int powersOfTwo = 2;

            int number = random.Next(minNumber, maxNumber);

            while (number >= result)
            {
                result *= powersOfTwo;
            }

            Console.WriteLine($"Число {number} двойка в степении {result}");
        }
    }
}
