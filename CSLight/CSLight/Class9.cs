using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Class9
    {
        static void Main()
        {
            Random random = new Random();

            int minValue = 0;
            int maxValue = 101;
            int multiples1 = 3;
            int multiples2 = 5;

            int number = random.Next(minValue, maxValue);
            
            int sum = number;

            Console.WriteLine(number);

            for (int i = 0; i < number; i++)
            {
                if (i % multiples1 == 0 || i % multiples2 == 0)
                {
                    sum += i;
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
