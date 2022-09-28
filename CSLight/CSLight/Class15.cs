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

            int numberRandom = random.Next(0, 100);
            int twoDegreeOne = 2;
            int twoDegreeTwo = 4;
            int twoDegreeThree = 8;
            int twoDegreeFour = 16;
            int twoDegreeFire = 32;
            int twoDegreeSix = 64;
            int twoDegreeSeven = 128;

            string degree = "Кратные";

            for (int i = 0; i < numberRandom; i++)
            {
                if (numberRandom <= twoDegreeOne)
                {
                    Console.WriteLine($"{numberRandom} {degree} 1 {twoDegreeOne}");
                    break;
                }

                if (numberRandom <= twoDegreeTwo)
                {
                    Console.WriteLine($"{numberRandom} {degree} 2 {twoDegreeTwo}");
                    break;
                }

                if (numberRandom <= twoDegreeThree)
                {
                    Console.WriteLine($"{numberRandom} {degree} 3 {twoDegreeThree}");
                    break;
                }

                if (numberRandom <= twoDegreeFour)
                {
                    Console.WriteLine($"{numberRandom} {degree} 4 {twoDegreeFour}");
                    break;
                }

                if (numberRandom <= twoDegreeFire)
                {
                    Console.WriteLine($"{numberRandom} {degree} 5 {twoDegreeFire}");
                    break;
                }

                if (numberRandom <= twoDegreeSix)
                {
                    Console.WriteLine($"{numberRandom} {degree} 6 {twoDegreeSix}");
                    break;
                }

                if (numberRandom <= twoDegreeSeven)
                {
                    Console.WriteLine($"{numberRandom} {degree} 7 {twoDegreeSeven}");
                    break;
                }
            }
        }
    }
}
