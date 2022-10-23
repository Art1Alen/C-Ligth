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
            int degrees = 2;
            int degreesCount = 0;

            int number = random.Next(minNumber, maxNumber);

            while (number > result)
            {
                result *= degrees;
                degreesCount++;
            }
            Console.WriteLine($"{number} < {result} где {result} в {degrees} степении {degreesCount}");
        }
    }
}
