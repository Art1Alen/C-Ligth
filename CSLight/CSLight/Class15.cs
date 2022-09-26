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
            int doble = 2;
            int result = numberRandom * doble;

            Console.WriteLine($"{numberRandom} {result}");

        }
    }
}
